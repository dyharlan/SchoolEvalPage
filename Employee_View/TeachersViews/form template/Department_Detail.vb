Imports System.Text
Imports Org.BouncyCastle.Math.EC

Public Class Department_Detail
    Dim departmentBS As New BindingSource
    Dim _department As New Department
    Private hasChanges As Boolean = False
    Private addFlag As Boolean = False
    Dim rowPosition As Integer

    Public Property HasChanges1 As Boolean
        Get
            Return hasChanges
        End Get
        Set(value As Boolean)
            hasChanges = value
        End Set
    End Property

    Sub addNew()
        Me.txtDeptId.Text = Nothing
        Me.txtDeptName.Text = Nothing
        Me.txtDeptId.Enabled = True
        Me.txtDeptName.Enabled = True
        _department = Nothing
        addFlag = True
        Me.Label6.Text = Me.Label6.Text & " [NEW]"

        Me.btnNew.Text = "Save"
        Me.btnEdit.Text = "Cancel"
        Me.btnDelete.Enabled = False

        Me.txtDeptId.Focus()

    End Sub
    Sub edit(department As Department)
        _department = department
        Me.txtDeptId.Text = department.DeptID1
        Me.txtDeptName.Text = department.DeptName1
        addFlag = False
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If (Me.btnNew.Text = "New") Then
            addNew()
        Else
            If save() Then
                loadList()
                Me.btnNew.Text = "New"
                Me.btnEdit.Text = "Edit"
                Me.btnDelete.Enabled = True
            End If
        End If

    End Sub

    Function save() As Integer

        Dim _deptId As String = Trim(Me.txtDeptId.Text)
        Dim _deptName As String = Me.txtDeptName.Text

        HasChanges1 = 0

        If IsNumeric(_deptId) = False Then
            ErrorProvider1.SetError(txtDeptId, "Invalid Department Id.")
            Me.txtDeptId.Focus()
            Return 0
        Else
            ErrorProvider1.SetError(txtDeptId, "")
        End If
        Dim result As Integer

        Dim department As New Department
        department.DeptID1 = _deptId
        department.DeptName1 = _deptName

        If addFlag Then
            result = department.save()
        Else
            result = department.update(_department.DeptID1)
        End If

        HasChanges1 = result
        Return HasChanges1

    End Function

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If Me.btnEdit.Text = "Edit" Then
            edit()
        Else
            Me.btnNew.Text = "New"
            Me.btnEdit.Text = "Edit"
            Me.btnDelete.Enabled = True
            Me.txtDeptId.Enabled = False
            Me.txtDeptName.Enabled = False
            addFlag = False
        End If

    End Sub

    Sub edit()
        If Me.departmentBS.Count = 0 Then
            Return
        End If
        Dim row = departmentBS.Current
        rowPosition = departmentBS.Position

        Dim _deptId As Integer= row.item("DEPT_ID")
        Dim _deptName As String = row.item("DEPT_NAME")

        _department.DeptID1 = _deptId
        _department.DeptName1 = _deptName

        Me.txtDeptId.Text = _deptId
        Me.txtDeptName.Text = _deptName

        Me.txtDeptId.Enabled = True
        Me.txtDeptName.Enabled = True
        Me.btnNew.Text = "Save"
        Me.btnEdit.Text = "Cancel"
        Me.btnDelete.Enabled = False
        addFlag = False
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Me.departmentBS.Count > 0 Then
            Dim row = departmentBS.Current
            If MsgBox("Do yo want to delete " & row.item("DEPT_ID") & "," & row.item("DEPT_NAME") & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                _department.DeptID1 = row.item("DEPT_ID")
                HasChanges1 = _department.delete()
                If HasChanges1 Then
                    departmentBS.RemoveCurrent()
                End If
            End If
        End If
    End Sub

    Sub loadList()
        Dim department As New Department
        departmentBS = department.all
        Me.DataGridView1.DataSource = departmentBS
        departmentBS.Position = rowPosition
        Me.txtDeptId.Enabled = False
        Me.txtDeptName.Enabled = False
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    Sub init()
        loadList()
    End Sub
    Private Sub Department_Detail_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        edit()
    End Sub
End Class