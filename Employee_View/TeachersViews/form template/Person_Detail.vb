Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Mysqlx.XDevAPI.Common

Public Class Person_Detail
    Dim _person As New Person
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
        loadPersonRole()
        Me.txtId.Text = Nothing
        Me.txtFname.Text = Nothing
        Me.txtMname.Text = Nothing
        Me.txtLname.Text = Nothing
        Me.cmbRoleId.SelectedValue = _person.RoleCode1
        _person = Nothing
        addFlag = True
        Me.Label6.Text = Me.Label6.Text & " [NEW]"
        Me.txtId.Focus()

    End Sub
    Sub edit(person As Person)
        loadPersonRole()
        _person = person
        Me.txtId.Text = person.PersonId1
        Me.txtFname.Text = person.FirstName1
        Me.txtMname.Text = person.MiddleName1
        Me.txtLname.Text = person.LastName1
        Me.cmbRoleId.SelectedValue = person.RoleCode1
        addFlag = False
    End Sub

    Sub loadPersonRole()
        Dim person As New Person
        Me.cmbRoleId.DisplayMember = "ROLE_NAME"
        Me.cmbRoleId.ValueMember = "ROLE_CODE"
        Me.cmbRoleId.DataSource = person.lookUpPersonRole

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
        HasChanges1 = 0

        If IsNumeric(_txtId) = False Then
            ErrorProvider1.SetError(txtId, "Invalid Person Id.")
            Me.txtId.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(txtId, "")
        End If
        Dim result As Integer

        Dim person As New Person
        person.PersonId1 = _txtId
        person.FirstName1 = _firstName
        person.MiddleName1 = _middleName
        person.LastName1 = _lastName
        person.RoleCode1 = Me.cmbRoleId.SelectedValue

        If addFlag Then
            result = person.save()
        Else
            result = person.update(_person.PersonId1)
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
        If MsgBox("Do yo want to delete " & _person.LastName1 & "," & _person.FirstName1 & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            HasChanges1 = _person.delete()
            If HasChanges1 Then
                Me.Close()
            End If
        End If

    End Sub
End Class