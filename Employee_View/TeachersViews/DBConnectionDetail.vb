Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Text
Imports Microsoft.SqlServer
Imports Org.BouncyCastle.Crypto.Tls

Public Class DBConnectionDetail


    Sub getConnection()
        Dim db As New Db
        Dim conn As String = SERVER_NAME
        Me.txtConnection.Text = conn
    End Sub

    Private Sub DBConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        getConnection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        testConnection()
    End Sub
    Function testConnection() As Integer
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Try
            Dim conString = Trim(Me.txtConnection.Text)
            If conString = Nothing Then
                MsgBox("Connection string cannot be empty.")
                Return 0
            End If

            conn.ConnectionString = conString
            conn.Open()
            MsgBox("Connected")
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            Return 0
        End Try

        Return 1

    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If testConnection() = 1 Then
            SERVER_NAME = Me.txtConnection.Text
            CONN_STATUS = SERVER_STATE.CONNECTED
            Me.Close()
        End If
    End Sub

    Sub createConnectionString()

        Try

            Dim _host As String = Trim(Me.txtHost.Text)
            Dim _user As String = Trim(Me.txtUser.Text)
            Dim _pass As String = Trim(Me.txtPassword.Text)
            Dim _port As String = Trim(Me.txtPort.Text)

            If IsNumeric(_port) = False Then
                _port = 0
            End If

            'If _host = Nothing Or _user = Nothing Or _port = Nothing Then
            '    MsgBox("Invalid connection string.", MsgBoxStyle.Critical)
            '    Return
            'End If


            Dim str As StringBuilder = New StringBuilder()
            str.Append("server=").Append(_host)
            str.Append(";user=").Append(_user)
            str.Append(";password=").Append(_pass)
            str.Append(";database=").Append(DATABASE_NAME)
            str.Append(";port=").Append(_port)
            str.Append(";")

            Me.txtConnection.Text = str.ToString

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtHost_TextChanged(sender As Object, e As EventArgs) Handles txtHost.TextChanged
        createConnectionString()

    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged
        createConnectionString()

    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        createConnectionString()

    End Sub

    Private Sub txtPort_TextChanged(sender As Object, e As EventArgs) Handles txtPort.TextChanged
        createConnectionString()

    End Sub

    Private Sub DBConnectionDetail_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class