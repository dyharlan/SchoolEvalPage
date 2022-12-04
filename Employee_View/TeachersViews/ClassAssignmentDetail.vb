Imports System.ComponentModel.Design
Imports System.Dynamic
Imports Microsoft.VisualBasic.FileIO
Imports Mysqlx.XDevAPI.Relational
Imports Org.BouncyCastle.Crypto.Engines

Public Class ClassAssignmentDetail
    Dim classAssignmentBS As New BindingSource
    Private rowPosition As Integer
    Sub init()
        loadStudent()
        loadClass()
        loadClassAssignment()
    End Sub

    Sub loadStudent()
        Dim student As New Student
        Dim studentBs As BindingSource = student.lookUpStudent
        studentBs.AddNew()
        Dim newRow = studentBs.Current
        newRow.item("STU_NUM") = 0
        newRow.item("STUDENT_NAME") = ""

        Me.cmbStudent.DisplayMember = "STUDENT_NAME"
        Me.cmbStudent.ValueMember = "STU_NUM"
        Me.cmbStudent.DataSource = studentBs



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
    Sub loadClassAssignment()
        Dim classAssignment As New ClassAssignment
        classAssignmentBS = classAssignment.all()
        Me.DataGridView1.DataSource = classAssignmentBS
        classAssignmentBS.Position = rowPosition
        Me.tsTotal.Text = "Total: " & classAssignmentBS.Count

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Me.cmbStudent.Text = Nothing Or Me.cmbClass.Text = Nothing Then
            MsgBox("Student and Class cannot be empty.", MsgBoxStyle.Critical)
            Return
        End If


        Dim stunum As Integer
        Dim classCode As Integer
        Dim result As Integer

        stunum = Me.cmbStudent.SelectedValue
        classCode = Me.cmbClass.SelectedValue

        If stunum = 0 Or classCode = 0 Then
            MsgBox("Student and Class cannot be empty.", MsgBoxStyle.Critical)
            Return
        End If

        Dim classassignment As New ClassAssignment
        classassignment.StudentNumber1 = stunum
        classassignment.ClassCode1 = classCode
        result = classassignment.save()
        If result > 0 Then
            loadClassAssignment()
            Me.cmbStudent.SelectedValue = 0
            Me.cmbClass.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStudent.SelectedIndexChanged
        'If Me.cmbStudent.Text = Nothing Then
        '    Return
        'End If
        'Dim val = Me.cmbStudent.SelectedValue
        'loadClassAssignment()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If classAssignmentBS.Count > 0 Then
            Dim row = classAssignmentBS.Current
            If MsgBox("Delete class assignment for " & row.Item("STUDENT") & " ?", MsgBoxStyle.YesNo) = vbYes Then

                Dim ca As New ClassAssignment
                ca.ClassCode1 = row.Item("CLASS_CODE")
                ca.StudentNumber1 = row.Item("STU_NUM")
                If ca.delete > 0 Then
                    classAssignmentBS.RemoveCurrent()
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
        Dim studentDetail As New StudentDetail
        studentDetail.addNew()
        studentDetail.ShowDialog()
        loadStudent()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Me.cmbStudent.SelectedValue > 0 Then
            filter("STU_NUM", Me.cmbStudent.SelectedValue)
        End If
    End Sub
    Sub filter(filterBy As String, value As Integer)
        Me.classAssignmentBS.RemoveFilter()
        Me.classAssignmentBS.Filter = filterBy & "='" & value & "'"
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If Me.cmbClass.SelectedValue > 0 Then
            filter("CLASS_CODE", Me.cmbClass.SelectedValue)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.classAssignmentBS.RemoveFilter()
        Me.cmbStudent.SelectedValue = 0
        Me.cmbClass.SelectedValue = 0

    End Sub

    Private Sub ClassAssignmentDetail_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CURRENT_ROLE = PERSON_ROLE.admin Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
End Class