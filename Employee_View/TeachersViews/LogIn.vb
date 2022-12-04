Public Class LogIn
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        login_verify()

    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        Dim db As New Db
        db.dropDatabase(db.getMySqlConnection)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim db As New Db
        db.dbaseFlag = Db.dbaseFlagType.initialize
        db.prepareDatabase()
    End Sub

    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            Me.LABEL1.Text = "STUDENT NUM:"
            CURRENT_ROLE = PERSON_ROLE.student
            Me.txtCode.SelectAll()
            Me.txtCode.Focus()

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            Me.LABEL1.Text = "TEACHERS CODE"
            CURRENT_ROLE = PERSON_ROLE.teacher
            Me.txtCode.PasswordChar = Nothing
            Me.txtCode.Text = Nothing
            Me.txtCode.SelectAll()
            Me.txtCode.Focus()

        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            Me.LABEL1.Text = "ADMIN CODE"
            CURRENT_ROLE = PERSON_ROLE.admin
            Me.txtCode.PasswordChar = "*"
            Me.txtCode.Text = Nothing
            Me.txtCode.SelectAll()
            Me.txtCode.Focus()
        End If
    End Sub

    Sub login_verify()

        If Trim(Me.txtCode.Text) = Nothing Then
            Return
        End If
        Try



            Select Case CURRENT_ROLE
                Case 0
                    Return

                Case 1
                    MsgBox("Student is currently restricted!", MsgBoxStyle.Critical)
                Case 2

                    Dim teacher As New Teacher
                    Dim code As String = Trim(Me.txtCode.Text)
                    If IsNumeric(code) = False Then
                        MsgBox("Invalid Teacher Code.", MsgBoxStyle.Critical)
                        Return
                    End If
                    Dim result As Boolean = teacher.isTeacherCodeExist(txtCode.Text)
                    If result = True Then
                        CURRENT_ROLE = PERSON_ROLE.teacher
                        MainForm.tsUser.Text = CURRENT_USER
                        MainForm.isMenuEnabled(True)
                        Me.Close()
                    Else
                        MsgBox("Access Denied!")
                        Me.txtCode.SelectAll()
                        Me.txtCode.Focus()

                    End If
                    CURRENT_ROLE = PERSON_ROLE.teacher
                Case 3
                    Dim password As String = "admin"
                    If txtCode.Text = password Then
                        CURRENT_ROLE = PERSON_ROLE.admin
                        MainForm.tsUser.Text = "Administrator"

                        MainForm.ToolStripMenuItem1.Enabled = True
                        MainForm.isMenuEnabled(True)
                        Me.Close()

                    Else
                        MsgBox("Access Denied!")
                        Me.txtCode.SelectAll()
                        Me.txtCode.Focus()
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged

    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress

    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            login_verify()
        End If
    End Sub
End Class
