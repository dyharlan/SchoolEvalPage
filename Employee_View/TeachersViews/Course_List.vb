Public Class Course_List
    Dim courseBS As New BindingSource
    Private rowPosition As Integer

    Sub loadList()
        Dim course As New Course
        courseBS = course.all
        Me.DataGridView1.DataSource = courseBS
        courseBS.Position = rowPosition
    End Sub
    Sub performFilter()


        Dim code As Integer = Me.cmbRolefilter.SelectedValue

        If code = 0 Then
            courseBS.RemoveFilter()
        Else
            courseBS.Filter = "ROLE_CODE='" & code & "'"
        End If


    End Sub
    Sub init()

        loadList()
        Me.cmbSearchCriteria.SelectedIndex = 1

    End Sub
    Private Sub Person_List_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim courseDetail As New Course_Detail
        courseDetail.addNew()
        courseDetail.ShowDialog()
        If courseDetail.HasChanges1 Then
            loadList()
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        viewDetail()
    End Sub
    Sub viewDetail()
        If courseBS.Count > 0 Then
            rowPosition = courseBS.Position
            Dim row = courseBS.Current
            Dim course As New Course()
            With course
                .CourseCode1 = row.item("COURSE_CODE")
                .CourseName1 = row.item("COURSE_NAME")


            End With

            Dim courseDetail As New Course_Detail
            courseDetail.edit(course)
            courseDetail.ShowDialog()
            If courseDetail.HasChanges1 Then
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
            Me.courseBS.RemoveFilter()
            Return
        End If

        Select Case cmbSearchCriteria.Text
            Case "COURSE CODE"
                courseBS.Filter = "COURSE_CODE='" & value & "'"
                Return
            Case "COURSE NAME"
                criteria = "COURSE_NAME"

        End Select
        If criteria = Nothing Then
            Me.courseBS.RemoveFilter()
            Return
        End If
        courseBS.Filter = criteria & " like '%" & value & "%'"


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
        If courseBS.Count > 0 Then
            rowPosition = courseBS.Position
            Dim row = courseBS.Current

            If MsgBox("Do yo want to delete " & row.item("COURSE_CODE") & "," & row.item("COURSE_NAME") & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim course As New Course
                course.CourseCode1 = row.item("COURSE_CODE")
                Dim result = course.delete()
                If result Then
                    courseBS.RemoveCurrent()
                End If
            End If
        End If
    End Sub
End Class