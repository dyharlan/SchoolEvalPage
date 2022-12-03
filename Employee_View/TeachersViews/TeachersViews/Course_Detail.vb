Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Mysqlx.XDevAPI.Common

Public Class Course_Detail
    Dim _course As New Course
    Private hasChanges As Boolean = False
    Private addFlag As Boolean = False


    Public Property HasChanges1 As Boolean
        Get
            Return hasChanges
        End Get
        Set(value As Boolean)
            hasChanges = value
        End Set
    End Property

    Sub addNew()

        Me.txtCourseCode.Text = Nothing
        Me.txtCourseName.Text = Nothing

        _course = Nothing
        addFlag = True
        Me.Label6.Text = Me.Label6.Text & " [NEW]"
        Me.txtCourseCode.Focus()

    End Sub
    Sub edit(course As Course)

        _course = course
        Me.txtCourseCode.Text = course.CourseCode1
        Me.txtCourseName.Text = course.CourseName1

        addFlag = False
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If save() Then
            Me.Close()
        End If
    End Sub

    Function save() As Integer

        Dim _courseCode As String = Trim(Me.txtCourseCode.Text)
        Dim _courseName As String = Me.txtCourseName.Text

        HasChanges1 = 0

        If IsNumeric(_courseCode) = False Then
            ErrorProvider1.SetError(txtCourseCode, "Invalid Person Id.")
            Me.txtCourseCode.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(txtCourseCode, "")
        End If
        Dim result As Integer

        Dim course As New Course
        course.CourseCode1 = _courseCode
        course.CourseName1 = _courseName

        If addFlag Then
            result = course.save()
        Else
            result = course.update(_course.CourseCode1)
        End If

        HasChanges1 = result
        Return HasChanges1

    End Function

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If save() Then
            addNew()
        End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If addFlag = False Then
            If MsgBox("Do yo want to delete " & _course.CourseCode1 & "," & _course.CourseName1 & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HasChanges1 = _course.delete()
                If HasChanges1 Then
                    Me.Close()
                End If
            End If
        End If
    End Sub
End Class