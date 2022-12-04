Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Mysqlx.XDevAPI.Common

Public Class StudentDetail
    Dim _student As New Student
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

        Me.txtId.Text = Nothing
        Me.txtFname.Text = Nothing
        Me.txtMname.Text = Nothing
        Me.txtLname.Text = Nothing
        Me.txtStudNum.Text = Nothing
        Me.txtYrStarted.Text = Nothing
        _student = Nothing
        addFlag = True
        Me.Label6.Text = Me.Label6.Text & " [NEW]"
        Me.txtFname.Focus()

    End Sub
    Sub edit(student As Student)

        _student = student
        Me.txtId.Text = student.PersonId1
        Me.txtFname.Text = student.FirstName1
        Me.txtMname.Text = student.MiddleName1
        Me.txtLname.Text = student.LastName1
        Me.txtStudNum.Text = student.StuNum1
        Me.txtYrStarted.Text = student.YrStart1
        addFlag = False
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If save() Then
            Me.Close()
        End If
    End Sub



    Function save() As Integer

        Dim _txtId As String = Trim(Me.txtId.Text)
        Dim _firstName As String = Me.txtFname.Text
        Dim _middleName As String = Trim(Me.txtMname.Text)
        Dim _lastName As String = Trim(Me.txtLname.Text)
        Dim _dob As Date = Me.dtpDOB.Value
        Dim _studNum As String = Trim(Me.txtStudNum.Text)
        Dim _yrStarted As String = Trim(Me.txtYrStarted.Text)



        HasChanges1 = 0

        If _firstName = Nothing Or IsNumeric(_firstName) Then
            ErrorProvider1.SetError(Me.txtFname, "Invalid First Name.")
            Me.txtFname.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(Me.txtFname, "")
        End If

        If _middleName = Nothing Or IsNumeric(_middleName) Then
            ErrorProvider1.SetError(Me.txtMname, "Invalid Middle Name .")
            Me.txtMname.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(Me.txtMname, "")
        End If

        If _lastName = Nothing Or IsNumeric(_lastName) Then
            ErrorProvider1.SetError(Me.txtLname, "Invalid Last Name.")
            Me.txtLname.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(Me.txtLname, "")
        End If

        If IsNumeric(_studNum) = False Then
            ErrorProvider1.SetError(Me.txtStudNum, "Invalid Student Number.")
            Me.txtStudNum.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(Me.txtStudNum, "")
        End If

        If IsDate(_dob) = False Then
            ErrorProvider1.SetError(Me.dtpDOB, "Invalid Data of Birth")
            Me.dtpDOB.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(Me.dtpDOB, "")
        End If

        If IsNumeric(_yrStarted) = False Then
            ErrorProvider1.SetError(Me.txtYrStarted, "Invalid Year Started.")
            Me.txtYrStarted.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(Me.txtYrStarted, "")
        End If


        If isStudentTeacherNumValid(_studNum) = False Then
            MsgBox("Invalid Student Number", MsgBoxStyle.Critical)
            Me.txtStudNum.Focus()
            Me.txtStudNum.SelectAll()
            Return 0
        End If


        Dim result As Integer

        Dim student As New Student
        'student.PersonId1 = _txtId
        student.FirstName1 = _firstName
        student.MiddleName1 = _middleName
        student.LastName1 = _lastName
        student.Dob1 = _dob
        student.StuNum1 = _studNum
        student.YrStart1 = _yrStarted
        student.RoleCode1 = PERSON_ROLE.student
        If addFlag Then
            result = student.save()
        Else
            result = student.update(_student.PersonId1)
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
            If MsgBox("Do yo want to delete " & _student.LastName1 & "," & _student.FirstName1 & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HasChanges1 = _student.updateStatus(_student.PersonId1, 2) '_student.delete()
                If HasChanges1 Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub StudentDetail_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'If CURRENT_ROLE = PERSON_ROLE.admin Then
        '    ToolStripButton1.Enabled = True
        '    ToolStripButton2.Enabled = True
        '    ToolStripButton4.Enabled = True
        'Else
        '    ToolStripButton1.Enabled = False
        '    ToolStripButton2.Enabled = False
        '    ToolStripButton4.Enabled = False
        'End If
    End Sub
End Class