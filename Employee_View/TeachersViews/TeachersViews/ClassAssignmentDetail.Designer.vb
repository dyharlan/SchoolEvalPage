<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClassAssignmentDetail
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
        Me.STUDENTNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLASSCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLASSNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STU_NUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbStudent = New System.Windows.Forms.ComboBox()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
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
        Me.Label6.Size = New System.Drawing.Size(215, 24)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "CLASS ASSIGNMENT"
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.STUDENTNAME, Me.CLASSCODE, Me.CLASSNAME, Me.STU_NUM, Me.Column1})
        Me.DataGridView1.Location = New System.Drawing.Point(10, 166)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(537, 287)
        Me.DataGridView1.TabIndex = 2
        '
        'STUDENTNAME
        '
        Me.STUDENTNAME.DataPropertyName = "STUDENT"
        Me.STUDENTNAME.HeaderText = "STUDENT"
        Me.STUDENTNAME.Name = "STUDENTNAME"
        Me.STUDENTNAME.ReadOnly = True
        '
        'CLASSCODE
        '
        Me.CLASSCODE.DataPropertyName = "CLASS_CODE"
        Me.CLASSCODE.HeaderText = "CLASS CODE"
        Me.CLASSCODE.Name = "CLASSCODE"
        Me.CLASSCODE.ReadOnly = True
        '
        'CLASSNAME
        '
        Me.CLASSNAME.DataPropertyName = "CLASS_NAME"
        Me.CLASSNAME.HeaderText = "CLASS NAME"
        Me.CLASSNAME.Name = "CLASSNAME"
        Me.CLASSNAME.ReadOnly = True
        '
        'STU_NUM
        '
        Me.STU_NUM.DataPropertyName = "STU_NUM"
        Me.STU_NUM.HeaderText = "STU_NUM"
        Me.STU_NUM.Name = "STU_NUM"
        Me.STU_NUM.ReadOnly = True
        Me.STU_NUM.Visible = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ASSIGNED_TEACHER"
        Me.Column1.HeaderText = "ASSIGNED TEACHER"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbStudent)
        Me.GroupBox1.Controls.Add(Me.cmbClass)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(535, 102)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(253, 23)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(39, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "New"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(253, 50)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(39, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(435, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 45)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "ASSIGN"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "STUDENT : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CLASS : "
        '
        'cmbStudent
        '
        Me.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStudent.FormattingEnabled = True
        Me.cmbStudent.Location = New System.Drawing.Point(82, 24)
        Me.cmbStudent.Name = "cmbStudent"
        Me.cmbStudent.Size = New System.Drawing.Size(171, 21)
        Me.cmbStudent.TabIndex = 4
        '
        'cmbClass
        '
        Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(82, 51)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(171, 21)
        Me.cmbClass.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(9, 456)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 26)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(291, 23)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(39, 23)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "Filter"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(291, 50)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(39, 23)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "Filter"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(435, 68)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(89, 23)
        Me.Button7.TabIndex = 14
        Me.Button7.Text = "Clear Filter"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsTotal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 489)
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
        'ClassAssignmentDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 511)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ClassAssignmentDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClassAssignmentDetail"
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
    Friend WithEvents cmbStudent As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents STUDENTNAME As DataGridViewTextBoxColumn
    Friend WithEvents CLASSCODE As DataGridViewTextBoxColumn
    Friend WithEvents CLASSNAME As DataGridViewTextBoxColumn
    Friend WithEvents STU_NUM As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsTotal As ToolStripStatusLabel
End Class
