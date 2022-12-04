Public Class Teacher_List
    Dim teacherBS As New BindingSource
    Private rowPosition As Integer

    Sub loadList()
        Dim teacher As New Teacher
        teacherBS = teacher.all
        Me.DataGridView1.DataSource = teacherBS
        teacherBS.Position = rowPosition
        Me.tsTotal.Text = "Total: " & teacherBS.Count
    End Sub
    Sub performFilter()


        Dim id As Integer = Me.cmbDepartment.SelectedValue

        If id = 0 Then
            teacherBS.RemoveFilter()
        Else
            teacherBS.Filter = "DEPT_ID='" & id & "'"
        End If


    End Sub
    Sub init()
        loadClass()
        loadList()
        Me.cmbSearchCriteria.SelectedIndex = 1
        Me.cmbDepartment.SelectedValue = 0

    End Sub
    Private Sub Person_List_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub
    Sub loadClass()
        Dim department As New Department
        Dim departmentBs As BindingSource = department.lookUpDepartment
        departmentBs.AddNew()
        Dim newRow = departmentBs.Current
        newRow.item("DEPT_ID") = 0
        newRow.item("DEPT_NAME") = "All"

        Me.cmbDepartment.DisplayMember = "DEPT_NAME"
        Me.cmbDepartment.ValueMember = "DEPT_ID"
        Me.cmbDepartment.DataSource = departmentBs
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim teacherDetail As New Teacher_Detail
        teacherDetail.addNew()
        teacherDetail.ShowDialog()
        If teacherDetail.HasChanges1 Then
            loadList()
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        viewDetail()
    End Sub
    Sub viewDetail()
        If teacherBS.Count > 0 Then
            rowPosition = teacherBS.Position
            Dim row = teacherBS.Current
            Dim teacher As New Teacher()
            With teacher
                .PersonId1 = row.item("PERSON_ID")
                .FirstName1 = row.item("FNAME")
                .MiddleName1 = row.item("MNAME")
                .LastName1 = row.item("LNAME")
                .TeacherCode1 = row.item("TEACHERS_CODE")
                .DeptId1 = row.item("DEPT_ID")
                .Dob1 = row.item("DOB")
            End With

            Dim teacherDetail As New Teacher_Detail
            teacherDetail.edit(teacher)
            teacherDetail.ShowDialog()
            If teacherDetail.HasChanges1 Then
                loadList()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        viewDetail()
    End Sub

    Private Sub cmbRolefilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        performFilter()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        performSearch()
    End Sub
    Sub performSearch()
        Dim criteria As String = Nothing
        Dim value As String = Trim(Me.txtSearch.Text)
        If value = Nothing Then
            Me.teacherBS.RemoveFilter()
            Return
        End If

        Select Case cmbSearchCriteria.Text
            Case "ID"
                teacherBS.Filter = "PERSON_ID='" & value & "'"
                Return
            Case "FIRST NAME"
                criteria = "FNAME"
            Case "LAST NAME"
                criteria = "LNAME"
            Case "MIDDLE NAME"
                criteria = "MNAME"
        End Select
        If criteria = Nothing Then
            Me.teacherBS.RemoveFilter()
            Return
        End If
        teacherBS.Filter = criteria & " like '%" & value & "%'"


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.txtSearch.Text = Nothing
        Me.txtSearch.Focus()
    End Sub

    Private Sub cmbSearchCriteria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedIndexChanged
        performSearch()
        Me.txtSearch.SelectAll()
        Me.txtSearch.Focus()
    End Sub

    Private Sub Person_List_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.txtSearch.Focus()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        loadList()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If teacherBS.Count > 0 Then
            rowPosition = teacherBS.Position
            Dim row = teacherBS.Current

            If MsgBox("Do yo want to delete " & row.item("LNAME") & "," & row.item("FNAME") & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim teacher As New Teacher
                teacher.PersonId1 = row.item("PERSON_ID")
                Dim result = teacher.updateStatus(teacher.PersonId1, 2) 'teacher.delete()
                If result Then
                    teacherBS.RemoveCurrent()
                End If
            End If
        Else
            MsgBox("Teachers list is empty.", MsgBoxStyle.Critical)
        End If
    End Sub
End Class