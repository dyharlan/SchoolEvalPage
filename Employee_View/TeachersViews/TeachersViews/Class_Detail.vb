Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Mysqlx.XDevAPI.Common

Public Class Class_Detail
    Dim _class As New SchoolClass
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
    Sub init()
        loadTeacherCode()
    End Sub
    Sub loadTeacherCode()
        Dim teacher As New Teacher
        cmbTeacherCode.DisplayMember = "TEACHER_NAME"
        cmbTeacherCode.ValueMember = "TEACHER_CODE"
        cmbTeacherCode.DataSource = teacher.lookUpTeacher
    End Sub

    Sub addNew()


        Me.txtClassCode.Text = Nothing
        Me.txtClassName.Text = Nothing

        Me.cmbTeacherCode.SelectedIndex = -1
        _class = Nothing
        addFlag = True
        Me.Label6.Text = Me.Label6.Text & " [NEW]"
        Me.txtClassCode.Focus()

    End Sub
    Sub edit(editclass As SchoolClass)

        _class = editclass

        Me.txtClassCode.Text = editclass.ClassCode1
        Me.txtClassName.Text = editclass.ClassName1
        Me.cmbTeacherCode.SelectedValue = editclass.TeacherCode1
        addFlag = False
    End Sub

    'Sub loadPersonRole()
    '    Dim person As New Person
    '    Me.cmbRoleId.DisplayMember = "ROLE_NAME"
    '    Me.cmbRoleId.ValueMember = "ROLE_CODE"
    '    Me.cmbRoleId.DataSource = person.lookUpPersonRole

    'End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If save() Then
            Me.Close()
        End If
    End Sub

    Function save() As Integer


        Dim _classCode As String = Trim(Me.txtClassCode.Text)
        Dim _className As String = Trim(Me.txtClassName.Text)
        Dim _teacherCode As Integer = Me.cmbTeacherCode.SelectedValue
        HasChanges1 = 0

        If IsNumeric(_classCode) = False Then
            ErrorProvider1.SetError(txtClassCode, "Invalid Class code.")
            Me.txtClassCode.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(txtClassCode, "")
        End If
        Dim result As Integer

        Dim schoolclass As New SchoolClass
        schoolclass.ClassCode1 = _classCode
        schoolclass.ClassName1 = _className
        schoolclass.TeacherCode1 = _teacherCode


        If addFlag Then
            result = schoolclass.save()
        Else
            result = schoolclass.update(_class.ClassCode1)
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
            If MsgBox("Do yo want to delete " & _class.ClassCode1 & "," & _class.ClassName1 & "," & _class.TeacherCode1 & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HasChanges1 = _class.delete()
                If HasChanges1 Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub Class_Detail_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim teacherDetail As New Teacher_Detail
        teacherDetail.addNew()
        teacherDetail.ShowDialog()
        loadTeacherCode()
    End Sub
End Class