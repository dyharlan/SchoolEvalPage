<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsStudent = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsTeacher = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCourse = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AddNewCourseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.CourseListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CourseAssignmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsClass = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AddNewClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClassListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassAssignmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDepartment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConnectionConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserRolesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEvaluation = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EvalStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblConnStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsLogOut = New System.Windows.Forms.ToolStripButton()
        Me.tsUser = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsStudent, Me.ToolStripSeparator3, Me.tsTeacher, Me.ToolStripSeparator4, Me.tsCourse, Me.ToolStripSeparator6, Me.tsClass, Me.ToolStripSeparator7, Me.tsDepartment, Me.ToolStripSeparator5, Me.tsEvaluation, Me.tsLogOut, Me.ToolStripSeparator10, Me.tsUser, Me.ToolStripSeparator11})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1028, 50)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsStudent
        '
        Me.tsStudent.Image = CType(resources.GetObject("tsStudent.Image"), System.Drawing.Image)
        Me.tsStudent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsStudent.Name = "tsStudent"
        Me.tsStudent.Size = New System.Drawing.Size(76, 47)
        Me.tsStudent.Text = "STUDENT"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 50)
        '
        'tsTeacher
        '
        Me.tsTeacher.Image = CType(resources.GetObject("tsTeacher.Image"), System.Drawing.Image)
        Me.tsTeacher.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTeacher.Name = "tsTeacher"
        Me.tsTeacher.Size = New System.Drawing.Size(77, 47)
        Me.tsTeacher.Text = "TEACHER"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 50)
        '
        'tsCourse
        '
        Me.tsCourse.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewCourseToolStripMenuItem, Me.ToolStripSeparator8, Me.CourseListToolStripMenuItem, Me.CourseAssignmentToolStripMenuItem})
        Me.tsCourse.Image = CType(resources.GetObject("tsCourse.Image"), System.Drawing.Image)
        Me.tsCourse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCourse.Name = "tsCourse"
        Me.tsCourse.Size = New System.Drawing.Size(80, 47)
        Me.tsCourse.Text = "COURSE"
        '
        'AddNewCourseToolStripMenuItem
        '
        Me.AddNewCourseToolStripMenuItem.Name = "AddNewCourseToolStripMenuItem"
        Me.AddNewCourseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddNewCourseToolStripMenuItem.Text = "Add New Course"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(177, 6)
        '
        'CourseListToolStripMenuItem
        '
        Me.CourseListToolStripMenuItem.Name = "CourseListToolStripMenuItem"
        Me.CourseListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CourseListToolStripMenuItem.Text = "Course List"
        '
        'CourseAssignmentToolStripMenuItem
        '
        Me.CourseAssignmentToolStripMenuItem.Name = "CourseAssignmentToolStripMenuItem"
        Me.CourseAssignmentToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CourseAssignmentToolStripMenuItem.Text = "Course Assignment"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 50)
        '
        'tsClass
        '
        Me.tsClass.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewClassToolStripMenuItem, Me.ToolStripSeparator9, Me.ClassListToolStripMenuItem, Me.ClassAssignmentToolStripMenuItem})
        Me.tsClass.Image = CType(resources.GetObject("tsClass.Image"), System.Drawing.Image)
        Me.tsClass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClass.Name = "tsClass"
        Me.tsClass.Size = New System.Drawing.Size(70, 47)
        Me.tsClass.Text = "CLASS"
        '
        'AddNewClassToolStripMenuItem
        '
        Me.AddNewClassToolStripMenuItem.Name = "AddNewClassToolStripMenuItem"
        Me.AddNewClassToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddNewClassToolStripMenuItem.Text = "Add New Class"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(177, 6)
        '
        'ClassListToolStripMenuItem
        '
        Me.ClassListToolStripMenuItem.Name = "ClassListToolStripMenuItem"
        Me.ClassListToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClassListToolStripMenuItem.Text = "Class List"
        '
        'ClassAssignmentToolStripMenuItem
        '
        Me.ClassAssignmentToolStripMenuItem.Name = "ClassAssignmentToolStripMenuItem"
        Me.ClassAssignmentToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClassAssignmentToolStripMenuItem.Text = "Class Assignment"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 50)
        '
        'tsDepartment
        '
        Me.tsDepartment.Image = CType(resources.GetObject("tsDepartment.Image"), System.Drawing.Image)
        Me.tsDepartment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDepartment.Name = "tsDepartment"
        Me.tsDepartment.Size = New System.Drawing.Size(99, 47)
        Me.tsDepartment.Text = "DEPARTMENT"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 50)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.tsSetting, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'tsSetting
        '
        Me.tsSetting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.tsSetting.Name = "tsSetting"
        Me.tsSetting.Size = New System.Drawing.Size(56, 20)
        Me.tsSetting.Text = "&Setting"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateDatabaseToolStripMenuItem, Me.ToolStripSeparator1, Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem, Me.ToolStripSeparator2, Me.ConnectionConfigToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem1.Text = "Database"
        '
        'CreateDatabaseToolStripMenuItem
        '
        Me.CreateDatabaseToolStripMenuItem.Name = "CreateDatabaseToolStripMenuItem"
        Me.CreateDatabaseToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CreateDatabaseToolStripMenuItem.Text = "Create Database"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BackupToolStripMenuItem.Text = "Backup "
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(177, 6)
        '
        'ConnectionConfigToolStripMenuItem
        '
        Me.ConnectionConfigToolStripMenuItem.Name = "ConnectionConfigToolStripMenuItem"
        Me.ConnectionConfigToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ConnectionConfigToolStripMenuItem.Text = "Connection Config"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewUserToolStripMenuItem, Me.UserListToolStripMenuItem, Me.UserRolesToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem2.Text = "User Account"
        '
        'NewUserToolStripMenuItem
        '
        Me.NewUserToolStripMenuItem.Name = "NewUserToolStripMenuItem"
        Me.NewUserToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.NewUserToolStripMenuItem.Text = "New User"
        '
        'UserListToolStripMenuItem
        '
        Me.UserListToolStripMenuItem.Name = "UserListToolStripMenuItem"
        Me.UserListToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.UserListToolStripMenuItem.Text = "User List"
        '
        'UserRolesToolStripMenuItem
        '
        Me.UserRolesToolStripMenuItem.Name = "UserRolesToolStripMenuItem"
        Me.UserRolesToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.UserRolesToolStripMenuItem.Text = "User Roles"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'tsEvaluation
        '
        Me.tsEvaluation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EvalStatusToolStripMenuItem})
        Me.tsEvaluation.Image = CType(resources.GetObject("tsEvaluation.Image"), System.Drawing.Image)
        Me.tsEvaluation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEvaluation.Name = "tsEvaluation"
        Me.tsEvaluation.Size = New System.Drawing.Size(104, 47)
        Me.tsEvaluation.Text = "EVALUATION"
        '
        'EvalStatusToolStripMenuItem
        '
        Me.EvalStatusToolStripMenuItem.Name = "EvalStatusToolStripMenuItem"
        Me.EvalStatusToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EvalStatusToolStripMenuItem.Text = "Eval Status"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblConnStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 727)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblConnStatus
        '
        Me.lblConnStatus.Name = "lblConnStatus"
        Me.lblConnStatus.Size = New System.Drawing.Size(104, 17)
        Me.lblConnStatus.Text = "Server Connection"
        '
        'tsLogOut
        '
        Me.tsLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsLogOut.Image = CType(resources.GetObject("tsLogOut.Image"), System.Drawing.Image)
        Me.tsLogOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLogOut.Name = "tsLogOut"
        Me.tsLogOut.Size = New System.Drawing.Size(76, 47)
        Me.tsLogOut.Text = "LOG OUT"
        '
        'tsUser
        '
        Me.tsUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsUser.Name = "tsUser"
        Me.tsUser.Size = New System.Drawing.Size(30, 47)
        Me.tsUser.Text = "User"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 50)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 50)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 749)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsStudent As ToolStripButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsSetting As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CreateDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BackupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents NewUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserRolesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ConnectionConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsTeacher As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsCourse As ToolStripDropDownButton
    Friend WithEvents CourseListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CourseAssignmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsClass As ToolStripDropDownButton
    Friend WithEvents ClassListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassAssignmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsDepartment As ToolStripButton
    Friend WithEvents AddNewCourseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents AddNewClassToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents tsEvaluation As ToolStripDropDownButton
    Friend WithEvents EvalStatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsLogOut As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents tsUser As ToolStripLabel
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblConnStatus As ToolStripStatusLabel
End Class
