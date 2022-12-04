Imports System.Data.Common

Public Class MainForm
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsStudent.Click
        Dim personList As New Student_List()
        personList.MdiParent = Me
        personList.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ConnectionConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionConfigToolStripMenuItem.Click
        Dim dbCon As New DBConnectionDetail
        dbCon.ShowDialog()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles tsCourse.Click

    End Sub

    Private Sub CreateDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateDatabaseToolStripMenuItem.Click
        If MsgBox("Do you want to create database?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim db As New Db
            db.dbaseFlag = Db.dbaseFlagType.initialize
            db.prepareDatabase()

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles tsTeacher.Click
        Dim teacherList As New Teacher_List()

        teacherList.MdiParent = Me
        teacherList.Show()
    End Sub

    Private Sub ClassListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassListToolStripMenuItem.Click
        Dim classList As New Class_List

        classList.MdiParent = Me
        classList.Show()
    End Sub

    Private Sub ClassAssignmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassAssignmentToolStripMenuItem.Click
        Dim classAssign As New ClassAssignmentDetail

        classAssign.MdiParent = Me
        classAssign.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsDepartment.Click
        Dim department As New Department_Detail
        department.MdiParent = Me
        department.Show()
    End Sub



    Private Sub AddNewCourseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewCourseToolStripMenuItem.Click
        Dim Course_Detail As New Course_Detail
        Course_Detail.addNew()
        Course_Detail.MdiParent = Me
        Course_Detail.Show()
    End Sub

    Private Sub AddNewClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewClassToolStripMenuItem.Click
        Dim classDetail As New Class_Detail
        classDetail.addNew()
        classDetail.ShowDialog()
    End Sub

    Private Sub CourseAssignmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CourseAssignmentToolStripMenuItem.Click
        Dim courseAssignment As New CourseAssignmentDetail
        courseAssignment.MdiParent = Me
        courseAssignment.Show()

    End Sub

    Private Sub CourseListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CourseListToolStripMenuItem.Click
        Dim courseList As New Course_List

        courseList.MdiParent = Me
        courseList.Show()
    End Sub
    Sub init()
        isMenuEnabled(False)
        Me.tsUser.Text = Nothing
        Dim login As New LogIn
        login.MdiParent = Me
        login.Show()

        Select Case CURRENT_ROLE
            Case 0
                ToolStripMenuItem1.Enabled = False
            Case 1
                MsgBox("Student is restricted.", MsgBoxStyle.Critical)
            Case 2
                ToolStripMenuItem1.Enabled = False
                teacherMenu()
            Case 3
                ToolStripMenuItem1.Enabled = True
                adminMenu()
        End Select

        ToolStrip1.Visible = True
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        isMenuEnabled(False)
        If isServerConnected() = False Then
            Return
        End If

        init()

    End Sub
    Function isServerConnected() As Boolean
        Dim db As New Db
        db.getMySqlConnection()
        If CONN_STATUS = SERVER_STATE.CONNECTED Then
            Me.lblConnStatus.Text = "Connected"
            logOut()
        Else
            Me.lblConnStatus.Text = "Disconnected"
            Dim conDetail As New DBConnectionDetail
            conDetail.MdiParent = Me
            conDetail.Show()

        End If
        Return CONN_STATUS
    End Function
    Sub teacherMenu()
        Me.tsCourse.Enabled = True
        Me.tsSetting.Enabled = False
        Me.tsStudent.Enabled = True
        Me.tsTeacher.Enabled = True
        Me.tsDepartment.Enabled = True
        Me.tsClass.Enabled = True
        Me.tsEvaluation.Enabled = True
        Me.tsLogOut.Enabled = True
        AddNewCourseToolStripMenuItem.Enabled = False
    End Sub
    Sub adminMenu()
        Me.tsSetting.Enabled = True
        Me.tsStudent.Enabled = True
        Me.tsTeacher.Enabled = True
        Me.tsDepartment.Enabled = True
        Me.tsClass.Enabled = True
        Me.tsCourse.Enabled = True
        Me.tsEvaluation.Enabled = True
        Me.tsLogOut.Enabled = True
        AddNewCourseToolStripMenuItem.Enabled = True
    End Sub

    Sub isMenuEnabled(val As Boolean)
        Me.tsSetting.Enabled = val
        Me.tsStudent.Enabled = val
        Me.tsTeacher.Enabled = val
        Me.tsDepartment.Enabled = val
        Me.tsClass.Enabled = val
        Me.tsCourse.Enabled = val
        Me.tsEvaluation.Enabled = val
        Me.tsLogOut.Enabled = val
    End Sub

    Public Sub logOut()
        isMenuEnabled(False)
        ToolStripMenuItem1.Enabled = False
        Me.tsUser.Text = Nothing

        Dim login As New LogIn
        login.MdiParent = Me
        login.Show()

    End Sub

    Private Sub tsLogOut_Click(sender As Object, e As EventArgs) Handles tsLogOut.Click
        logOut()
    End Sub

    Private Sub EvalStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EvalStatusToolStripMenuItem.Click
        EvalScoreView.ShowDialog()
    End Sub
End Class
