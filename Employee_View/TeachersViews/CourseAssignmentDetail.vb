Imports System.ComponentModel.Design
Imports System.Dynamic
Imports Microsoft.VisualBasic.FileIO
Imports Mysqlx.XDevAPI.Relational
Imports Org.BouncyCastle.Crypto.Engines

Public Class CourseAssignmentDetail
    Dim courseAssignmentBS As New BindingSource
    Private rowPosition As Integer
    Sub init()
        loadTeacher()
        loadCourse()
        loadClass()
        loadCourseAssignment()
    End Sub

    Sub loadTeacher()
        Dim teacher As New Teacher
        Dim teacherBs As BindingSource = teacher.lookUpTeacher
        teacherBs.AddNew()
        Dim newRow = teacherBs.Current
        newRow.item("TEACHERS_CODE") = 0
        newRow.item("TEACHER_NAME") = ""

        Me.cmbTeacher.DisplayMember = "TEACHER_NAME"
        Me.cmbTeacher.ValueMember = "TEACHERS_CODE"
        Me.cmbTeacher.DataSource = teacherBs

    End Sub

    Sub loadCourse()
        Dim course As New Course
        Dim courseBs As BindingSource = course.lookUpCourse
        courseBs.AddNew()
        Dim newRow = courseBs.Current
        newRow.item("COURSE_CODE") = 0
        newRow.item("COURSE_NAME") = ""

        Me.cmbCourse.DisplayMember = "COURSE_NAME"
        Me.cmbCourse.ValueMember = "COURSE_CODE"
        Me.cmbCourse.DataSource = courseBs

    End Sub
    Sub loadClass()
        Dim schoolclass As New SchoolClass
        Dim classBs As BindingSource = schoolclass.lookUpClass
        classBs.AddNew()
        Dim newRow = classBs.Current
        newRow.item("CLASS_CODE") = 0
        newRow.item("CLASS_NAME") = ""

        Me.cmbClass.DisplayMember = "CLASS_NAME"
        Me.cmbClass.ValueMember = "CLASS_CODE"
        Me.cmbClass.DataSource = classBs
    End Sub
    Private Sub ClassAssignmentDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        init()
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged

    End Sub
    Sub loadCourseAssignment()
        Dim courseAssignment As New CourseAssignment
        courseAssignmentBS = courseAssignment.all()
        Me.DataGridView1.DataSource = courseAssignmentBS
        courseAssignmentBS.Position = rowPosition
        Me.tsTotal.Text = "Total: " & Me.courseAssignmentBS.Count
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        assign()
    End Sub
    Sub assign()
        If Me.cmbTeacher.Text = Nothing Or Me.cmbClass.Text = Nothing Or Me.cmbCourse.Text = Nothing Then
            MsgBox("Teacher, Course and Class cannot be empty.", MsgBoxStyle.Critical)
            Return
        End If


        Dim teacherCode As Integer
        Dim classCode As Integer
        Dim courseCode As Integer

        Dim result As Integer

        teacherCode = Me.cmbTeacher.SelectedValue
        classCode = Me.cmbClass.SelectedValue
        courseCode = Me.cmbCourse.SelectedValue

        If teacherCode = 0 Or classCode = 0 Or courseCode = 0 Then
            MsgBox("Teacher, Course and Class cannot be empty.", MsgBoxStyle.Critical)
            Return
        End If

        Dim courseAssignment As New CourseAssignment
        courseAssignment.TeacherCode1 = teacherCode
        courseAssignment.ClassCode1 = classCode
        courseAssignment.CourseCode1 = courseCode

        result = courseAssignment.save()
        If result > 0 Then
            loadCourseAssignment()
            Me.cmbTeacher.SelectedValue = 0
            Me.cmbCourse.SelectedValue = 0
            Me.cmbClass.SelectedValue = 0

        End If
    End Sub
    Private Sub cmbStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTeacher.SelectedIndexChanged
        'If Me.cmbStudent.Text = Nothing Then
        '    Return
        'End If
        'Dim val = Me.cmbStudent.SelectedValue
        'loadClassAssignment()
    End Sub
    Sub filter(filterBy As String, value As Integer)
        Me.courseAssignmentBS.RemoveFilter()
        Me.courseAssignmentBS.Filter = filterBy & "='" & value & "'"
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If courseAssignmentBS.Count > 0 Then
            Dim row = courseAssignmentBS.Current
            If (row.item("TEACHERS_CODE") <> CURRENT_TEACHER_CODE) Then
                MsgBox("ACCESS DENIED.", MsgBoxStyle.Critical)
            End If
            If MsgBox("Delete class assignment for " & row.Item("COURSE_CODE") & " ?", MsgBoxStyle.YesNo) = vbYes Then

                Dim course As New CourseAssignment
                course.ClassCode1 = row.Item("CLASS_CODE")
                course.CourseCode1 = row.Item("COURSE_CODE")
                course.TeacherCode1 = row.item("TEACHERS_CODE")

                If course.delete > 0 Then
                    courseAssignmentBS.RemoveCurrent()
                End If
            End If
        Else
            MsgBox("Record is empty.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim classDetail As New Class_Detail
        classDetail.addNew()
        classDetail.ShowDialog()
        loadClass()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim teacherDetail As New Teacher_Detail
        teacherDetail.addNew()
        teacherDetail.ShowDialog()
        loadTeacher()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Dim courseDetail As New Course_Detail
        courseDetail.addNew()
        courseDetail.ShowDialog()
        loadCourse()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Me.cmbTeacher.SelectedValue > 0 Then
            filter("TEACHER_CODE", Me.cmbTeacher.SelectedValue)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Me.cmbCourse.SelectedValue > 0 Then
            filter("COURSE_CODE", Me.cmbCourse.SelectedValue)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Me.cmbClass.SelectedValue > 0 Then
            filter("CLASS_CODE", Me.cmbClass.SelectedValue)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.courseAssignmentBS.RemoveFilter()
        Me.cmbTeacher.SelectedValue = 0
        Me.cmbCourse.SelectedValue = 0
        Me.cmbClass.SelectedValue = 0
    End Sub

    Private Sub CourseAssignmentDetail_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CURRENT_ROLE = PERSON_ROLE.admin Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
End Class