Public Class Class_List
    Dim classBS As New BindingSource
    Private rowPosition As Integer

    Sub loadList()
        Dim schoolclass As New SchoolClass
        classBS = schoolclass.all
        Me.DataGridView1.DataSource = classBS
        classBS.Position = rowPosition
        Me.tsTotal.Text = "Total: " & classBS.Count
    End Sub
    Sub performFilter()


        'Dim code As Integer = Me.cmbRolefilter.SelectedValue

        'If code = 0 Then
        '    classBS.RemoveFilter()
        'Else
        '    classBS.Filter = "ROLE_CODE='" & code & "'"
        'End If


    End Sub
    Sub init()

        loadList()
        Me.cmbSearchCriteria.SelectedIndex = 1

    End Sub
    Private Sub Person_List_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim schooldetail As New Class_Detail
        schooldetail.addNew()
        schooldetail.ShowDialog()
        If schooldetail.HasChanges1 Then
            loadList()
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        viewDetail()
    End Sub
    Sub viewDetail()
        If classBS.Count > 0 Then
            rowPosition = classBS.Position
            Dim row = classBS.Current
            Dim schoolclass As New SchoolClass()
            With schoolclass
                .ClassCode1 = row.item("CLASS_CODE")
                .ClassName1 = row.item("CLASS_NAME")
                .TeacherCode1 = row.item("TEACHERS_CODE")

            End With

            Dim classDetail As New Class_Detail
            classDetail.edit(schoolclass)
            classDetail.ShowDialog()
            If classDetail.HasChanges1 Then
                loadList()
            End If
        End If
    End Sub


    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        viewDetail()
    End Sub

    Private Sub cmbRolefilter_SelectedIndexChanged(sender As Object, e As EventArgs)
        performFilter()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        performSearch()
    End Sub
    Sub performSearch()
        Dim criteria As String = Nothing
        Dim value As String = Trim(Me.txtSearch.Text)
        If value = Nothing Then
            Me.classBS.RemoveFilter()
            Return
        End If

        Select Case cmbSearchCriteria.Text
            Case "CLASS CODE"
                classBS.Filter = "CLASS_CODE='" & value & "'"
                Return
            Case "CLASS NAME"
                criteria = "CODE_NAME"
            Case "TEACHER CODE"
                criteria = "TEACHERS_CODE"
        End Select
        If criteria = Nothing Then
            Me.classBS.RemoveFilter()
            Return
        End If
        classBS.Filter = criteria & " like '%" & value & "%'"


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
        If classBS.Count > 0 Then
            rowPosition = classBS.Position
            Dim row = classBS.Current

            If MsgBox("Do yo want to delete " & row.item("CLASS_CODE") & "," & row.item("CLASS_NAME") & "," & row.item("TEACHERS_CODE") & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim schoolclass As New SchoolClass
                schoolclass.ClassCode1 = row.item("CLASS_CODE")
                Dim result = schoolclass.delete()
                If result Then
                    classBS.RemoveCurrent()
                End If
            End If
        Else
            MsgBox("Record is empty.", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class