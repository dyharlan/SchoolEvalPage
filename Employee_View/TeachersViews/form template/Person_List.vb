Public Class Person_List
    Dim personBS As New BindingSource
    Private rowPosition As Integer

    Sub loadList()
        Dim person As New Person
        personBS = person.all
        Me.DataGridView1.DataSource = personBS
        personBS.Position = rowPosition
    End Sub
    Sub performFilter()


        Dim code As Integer = Me.cmbRolefilter.SelectedValue

        If code = 0 Then
            personBS.RemoveFilter()
        Else
            personBS.Filter = "ROLE_CODE='" & code & "'"
        End If


    End Sub
    Sub init()
        loadPersonRole()
        loadList()
        Me.cmbSearchCriteria.SelectedIndex = 1

    End Sub
    Private Sub Person_List_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub
    Sub loadPersonRole()
        Dim person As New Person
        Me.cmbRolefilter.DisplayMember = "ROLE_NAME"
        Me.cmbRolefilter.ValueMember = "ROLE_CODE"
        Dim bs As New BindingSource
        bs = person.lookUpPersonRole
        bs.AddNew()
        Dim p = bs.Current
        p.row.item("ROLE_CODE") = 0
        p.row.item("ROLE_NAME") = "All"
        Me.cmbRolefilter.DataSource = bs

    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim personDetail As New Person_Detail
        personDetail.addNew()
        personDetail.ShowDialog()
        If personDetail.HasChanges1 Then
            loadList()
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        viewDetail()
    End Sub
    Sub viewDetail()
        If personBS.Count > 0 Then
            rowPosition = personBS.Position
            Dim row = personBS.Current
            Dim person As New Person(
            row.item("PERSON_ID"),
            row.item("FNAME"),
            row.item("MNAME"),
            row.item("LNAME"),
            row.item("ROLE_CODE")
            )
            Dim personDetail As New Person_Detail
            personDetail.edit(person)
            personDetail.ShowDialog()
            If personDetail.HasChanges1 Then
                loadList()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        viewDetail()
    End Sub

    Private Sub cmbRolefilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRolefilter.SelectedIndexChanged
        performFilter()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        performSearch()
    End Sub
    Sub performSearch()
        Dim criteria As String = Nothing
        Dim value As String = Trim(Me.txtSearch.Text)
        If value = Nothing Then
            Me.personBS.RemoveFilter()
            Return
        End If

        Select Case cmbSearchCriteria.Text
            Case "ID"
                personBS.Filter = "PERSON_ID='" & value & "'"
                Return
            Case "FIRST NAME"
                criteria = "FNAME"
            Case "LAST NAME"
                criteria = "LNAME"
            Case "MIDDLE NAME"
                criteria = "MNAME"
        End Select
        If criteria = Nothing Then
            Me.personBS.RemoveFilter()
            Return
        End If
        personBS.Filter = criteria & " like '%" & value & "%'"


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
End Class