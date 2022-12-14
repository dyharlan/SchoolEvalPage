Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Mysqlx.XDevAPI.Common

Public Class Teacher_Detail
    Dim _teacher As New Teacher
    Private hasChanges As Boolean = False
    Private addFlag As Boolean = False

    Sub init()
        loadDepartment()
    End Sub
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
        Me.txtTeacherCode.Text = Nothing

        Me.cmbDepartment.SelectedValue = 0
        _teacher = Nothing
        addFlag = True
        Me.Label6.Text = Me.Label6.Text & " [NEW]"
        Me.txtFname.Focus()

    End Sub
    Sub edit(teacher As Teacher)

        _teacher = teacher
        Me.txtId.Text = teacher.PersonId1
        Me.txtFname.Text = teacher.FirstName1
        Me.txtMname.Text = teacher.MiddleName1
        Me.txtLname.Text = teacher.LastName1
        Me.txtTeacherCode.Text = teacher.TeacherCode1
        Me.cmbDepartment.SelectedValue = teacher.DeptId1
        If Not teacher.Dob1 = Nothing Then
            Me.dtpDOB.Value = teacher.Dob1
        End If

        addFlag = False
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If save() Then
            Me.Close()
        End If
    End Sub

    Function save() As Integer

        ' Dim _txtId As String = Trim(Me.txtId.Text)
        Dim _firstName As String = Me.txtFname.Text
        Dim _middleName As String = Trim(Me.txtMname.Text)
        Dim _lastName As String = Trim(Me.txtLname.Text)
        Dim _teacherCode As String = Trim(Me.txtTeacherCode.Text)
        Dim _dob As Date = Me.dtpDOB.Value
        Dim _departmentID As Integer = Me.cmbDepartment.SelectedValue

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


        If IsNumeric(_teacherCode) = False Then
            ErrorProvider1.SetError(Me.txtTeacherCode, "Invalid Teachers Code.")
            Me.txtTeacherCode.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(Me.txtTeacherCode, "")
        End If

        If isStudentTeacherNumValid(_teacherCode) = False Then
            MsgBox("Invalid Teacher Code", MsgBoxStyle.Critical)
            Me.txtTeacherCode.Focus()
            Me.txtTeacherCode.SelectAll()
            Return 0
        End If

        Dim result As Integer

        Dim teacher As New Teacher
        teacher.FirstName1 = _firstName
        teacher.MiddleName1 = _middleName
        teacher.LastName1 = _lastName
        teacher.TeacherCode1 = _teacherCode
        teacher.Dob1 = _dob
        teacher.DeptId1 = _departmentID
        teacher.RoleCode1 = PERSON_ROLE.teacher
        If addFlag Then
            result = teacher.save()
        Else
            result = teacher.update(_teacher.PersonId1)
        End If

        HasChanges1 = result
        Return HasChanges1

    End Function

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If save() Then
            If CURRENT_ROLE = PERSON_ROLE.admin Then
                addNew()
            Else
                MsgBox("ACCESS DENIED!", MsgBoxStyle.Critical)
            End If

        End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

        If CURRENT_ROLE = PERSON_ROLE.admin Then
            If addFlag = False Then
                If MsgBox("Do yo want to delete " & _teacher.LastName1 & "," & _teacher.FirstName1 & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    HasChanges1 = _teacher.updateStatus(_teacher.PersonId1, 2) '_teacher.delete()
                    If HasChanges1 Then
                        Me.Close()
                    End If
                End If
            End If
        Else
            MsgBox("ACCESS DENIED!", MsgBoxStyle.Critical)
        End If


    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub loadDepartment()
        Dim department As New Department
        Me.cmbDepartment.DisplayMember = "DEPT_NAME"
        Me.cmbDepartment.ValueMember = "DEPT_ID"
        Me.cmbDepartment.DataSource = department.lookUpDepartment

    End Sub

    Private Sub Teacher_Detail_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim departmentDet As New Department_Detail
        departmentDet.ShowDialog()
        loadDepartment()
    End Sub

    Private Sub Teacher_Detail_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CURRENT_ROLE = PERSON_ROLE.admin Then
            ToolStripButton1.Enabled = True
            ToolStripButton2.Enabled = True
            ToolStripButton4.Enabled = True
        Else
            ToolStripButton1.Enabled = False
            ToolStripButton2.Enabled = False
            ToolStripButton4.Enabled = False
        End If
    End Sub
End Class