<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewOption
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnViewEvalScores = New System.Windows.Forms.Button()
        Me.btnViewManageSections = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnViewEvalScores
        '
        Me.btnViewEvalScores.Location = New System.Drawing.Point(204, 76)
        Me.btnViewEvalScores.Name = "btnViewEvalScores"
        Me.btnViewEvalScores.Size = New System.Drawing.Size(263, 76)
        Me.btnViewEvalScores.TabIndex = 0
        Me.btnViewEvalScores.Text = "View Eval Status"
        Me.btnViewEvalScores.UseVisualStyleBackColor = True
        '
        'btnViewManageSections
        '
        Me.btnViewManageSections.Location = New System.Drawing.Point(204, 176)
        Me.btnViewManageSections.Name = "btnViewManageSections"
        Me.btnViewManageSections.Size = New System.Drawing.Size(263, 76)
        Me.btnViewManageSections.TabIndex = 1
        Me.btnViewManageSections.Text = "View Manage Sections"
        Me.btnViewManageSections.UseVisualStyleBackColor = True
        '
        'ViewOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 356)
        Me.Controls.Add(Me.btnViewManageSections)
        Me.Controls.Add(Me.btnViewEvalScores)
        Me.Name = "ViewOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ViewOption"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnViewEvalScores As Button
    Friend WithEvents btnViewManageSections As Button
End Class
