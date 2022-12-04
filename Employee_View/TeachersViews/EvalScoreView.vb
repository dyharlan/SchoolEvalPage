Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class EvalScoreView
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim assign As String = "SELECT * FROM evaluation.course_offerings"
    Dim holder As New Integer
    Dim holder1 As New Integer
    Public holder2 As String

    'Dim Server As String = "server=localhost;user=root;password=password;port=3310;database=evaluation"

    Private Sub EvalScoreView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        holder1 = CType(holder2, Integer)
        comboBoxLoad()
        loadTable()
    End Sub

    Private Sub loadTable()
        sqlDt.Clear()
        DataGridView1.DataSource = sqlDt
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()

        sqlConn.ConnectionString = Main.SERVER_NAME

        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "call check_eval_scores('" & holder1 & "','" & holder & "');"

        sqlRd = sqlCmd.ExecuteReader

        sqlDt.Load(sqlRd)
        sqlRd.Close()
        sqlConn.Close()
        DataGridView1.DataSource = sqlDt

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub comboBoxLoad()
        Dim sqlCon As New MySqlConnection
        Dim sqlCom As New MySqlCommand(assign, sqlCon)
        sqlCon.ConnectionString = Main.SERVER_NAME

        sqlCon.Open()
        Dim sqlTbl As New DataTable()
        sqlTbl.Load(sqlCom.ExecuteReader)
        ComboBox1.DataSource = sqlTbl
        ComboBox1.DisplayMember = "COURSE_CODE"
        sqlConn.Close()

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        holder = CType(ComboBox1.Text, Integer)
        loadTable()
    End Sub
End Class