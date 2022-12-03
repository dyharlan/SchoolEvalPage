Public Class Student_List
    Dim studentBS As New BindingSource
    Private rowPosition As Integer

    Sub loadList()
        Dim student As New Student
        studentBS = student.all
        Me.DataGridView1.DataSource = studentBS
        studentBS.Position = rowPosition
        Me.tsTotal.Text = "Total: " & studentBS.Count
    End Sub

    Sub init()
        loadList()
        Me.cmbSearchCriteria.SelectedIndex = 1

    End Sub
    Private Sub Person_List_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim studentDetail As New StudentDetail
        studentDetail.addNew()
        studentDetail.ShowDialog()
        If studentDetail.HasChanges1 Then
            loadList()
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        viewDetail()
    End Sub
    Sub viewDetail()
        If studentBS.Count > 0 Then
            rowPosition = studentBS.Position
            Dim row = studentBS.Current
            Dim student As New Student()
            With student
                .PersonId1 = row.item("PERSON_ID")
                .FirstName1 = row.item("FNAME")
                .MiddleName1 = row.item("MNAME")
                .LastName1 = row.item("LNAME")
                .StuNum1 = row.item("STU_NUM")
                .YrStart1 = row.item("YR_START")
            End With

            Dim personDetail As New StudentDetail
            personDetail.edit(student)
            personDetail.ShowDialog()
            If personDetail.HasChanges1 Then
                loadList()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        viewDetail()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        performSearch()
    End Sub
    Sub performSearch()
        Dim criteria As String = Nothing
        Dim value As String = Trim(Me.txtSearch.Text)
        If value = Nothing Then
            Me.studentBS.RemoveFilter()
            Return
        End If

        Select Case cmbSearchCriteria.Text
            Case "ID"
                If IsNumeric(value) Then
                    studentBS.Filter = "PERSON_ID='" & value & "'"
                End If

                Return
                    Case "FIRST NAME"
                    criteria = "FNAME"
                    Case "LAST NAME"
                    criteria = "LNAME"
                    Case "MIDDLE NAME"
                    criteria = "MNAME"
        End Select
        If criteria = Nothing Then
            Me.studentBS.RemoveFilter()
            Return
        End If
        studentBS.Filter = criteria & " like '%" & value & "%'"


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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        If studentBS.Count > 0 Then
            rowPosition = studentBS.Position
            Dim row = studentBS.Current

            If MsgBox("Do yo want to delete " & row.item("LNAME") & "," & row.item("FNAME") & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim student As New Student
                student.PersonId1 = row.item("PERSON_ID")
                Dim result = student.delete()
                If result Then
                    studentBS.RemoveCurrent()
                End If
            End If
        Else
            MsgBox("Student list is empty.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class