<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CourseAssignmentDetail
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TEACHER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COURSE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLASS_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEACHER_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COURSE_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLASS_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTeacher = New System.Windows.Forms.ComboBox()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(559, 52)
        Me.Panel1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(235, 24)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "COURSE ASSIGNMENT"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TEACHER, Me.COURSE, Me.CLASS_NAME, Me.TEACHER_CODE, Me.COURSE_CODE, Me.CLASS_CODE})
        Me.DataGridView1.Location = New System.Drawing.Point(10, 180)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(537, 266)
        Me.DataGridView1.TabIndex = 2
        '
        'TEACHER
        '
        Me.TEACHER.DataPropertyName = "TEACHER"
        Me.TEACHER.HeaderText = "TEACHER"
        Me.TEACHER.Name = "TEACHER"
        Me.TEACHER.ReadOnly = True
        '
        'COURSE
        '
        Me.COURSE.DataPropertyName = "COURSE_NAME"
        Me.COURSE.HeaderText = "COURSE"
        Me.COURSE.Name = "COURSE"
        Me.COURSE.ReadOnly = True
        '
        'CLASS_NAME
        '
        Me.CLASS_NAME.DataPropertyName = "CLASS_NAME"
        Me.CLASS_NAME.HeaderText = "CLASS"
        Me.CLASS_NAME.Name = "CLASS_NAME"
        Me.CLASS_NAME.ReadOnly = True
        '
        'TEACHER_CODE
        '
        Me.TEACHER_CODE.DataPropertyName = "TEACHER_CODE"
        Me.TEACHER_CODE.HeaderText = "TEACHER_CODE"
        Me.TEACHER_CODE.Name = "TEACHER_CODE"
        Me.TEACHER_CODE.ReadOnly = True
        Me.TEACHER_CODE.Visible = False
        '
        'COURSE_CODE
        '
        Me.COURSE_CODE.DataPropertyName = "COURSE_CODE"
        Me.COURSE_CODE.HeaderText = "COURSE_CODE"
        Me.COURSE_CODE.Name = "COURSE_CODE"
        Me.COURSE_CODE.ReadOnly = True
        Me.COURSE_CODE.Visible = False
        '
        'CLASS_CODE
        '
        Me.CLASS_CODE.DataPropertyName = "CLASS_CODE"
        Me.CLASS_CODE.HeaderText = "CLASS_CODE"
        Me.CLASS_CODE.Name = "CLASS_CODE"
        Me.CLASS_CODE.ReadOnly = True
        Me.CLASS_CODE.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbCourse)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbTeacher)
        Me.GroupBox1.Controls.Add(Me.cmbClass)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(535, 116)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "Add Assignment"
        Me.GroupBox1.Text = "Add Assignment"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(258, 49)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(39, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "New"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "COURSE:"
        '
        'cmbCourse
        '
        Me.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Location = New System.Drawing.Point(87, 50)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(171, 21)
        Me.cmbCourse.TabIndex = 8
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(258, 22)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(39, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "New"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(258, 75)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(39, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(408, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 53)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "ASSIGN"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "TEACHER:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CLASS : "
        '
        'cmbTeacher
        '
        Me.cmbTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTeacher.FormattingEnabled = True
        Me.cmbTeacher.Location = New System.Drawing.Point(87, 23)
        Me.cmbTeacher.Name = "cmbTeacher"
        Me.cmbTeacher.Size = New System.Drawing.Size(171, 21)
        Me.cmbTeacher.TabIndex = 4
        '
        'cmbClass
        '
        Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(87, 76)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(171, 21)
        Me.cmbClass.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(10, 452)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 26)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(296, 22)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(39, 23)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Filter"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(296, 49)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(39, 23)
        Me.Button7.TabIndex = 12
        Me.Button7.Text = "Filter"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(296, 75)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(39, 23)
        Me.Button8.TabIndex = 13
        Me.Button8.Text = "Filter"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.Location = New System.Drawing.Point(408, 75)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(121, 29)
        Me.Button9.TabIndex = 14
        Me.Button9.Text = "Clear Filter"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(559, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsTotal
        '
        Me.tsTotal.Name = "tsTotal"
        Me.tsTotal.Size = New System.Drawing.Size(35, 17)
        Me.tsTotal.Text = "Total:"
        '
        'CourseAssignmentDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 504)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "CourseAssignmentDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Course Assignment"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbClass As ComboBox
    Friend WithEvents cmbTeacher As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents TEACHER As DataGridViewTextBoxColumn
    Friend WithEvents COURSE As DataGridViewTextBoxColumn
    Friend WithEvents CLASS_NAME As DataGridViewTextBoxColumn
    Friend WithEvents TEACHER_CODE As DataGridViewTextBoxColumn
    Friend WithEvents COURSE_CODE As DataGridViewTextBoxColumn
    Friend WithEvents CLASS_CODE As DataGridViewTextBoxColumn
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsTotal As ToolStripStatusLabel
End Class
