Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Department
    Private deptID As Integer
    Private deptName As String
    Dim db As Db = New Db()
    Private tableName As String = TABLE_DEPARTMENTS

    Public Sub New()
    End Sub
    Public Sub New(deptID As Integer, deptName As String)
        Me.deptID = deptID
        Me.deptName = deptName
    End Sub

    Public Property DeptID1 As Integer
        Get
            Return deptID
        End Get
        Set(value As Integer)
            deptID = value
        End Set
    End Property

    Public Property DeptName1 As String
        Get
            Return deptName
        End Get
        Set(value As String)
            deptName = value
        End Set
    End Property


    Public Overloads Function save() As Integer


        Dim conn As MySqlConnection = db.getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("INSERT INTO " & tableName & " ")
            sql.Append("(")

            sql.Append("DEPT_ID,")
            sql.Append("DEPT_NAME")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@deptId,")
            sql.Append("@deptName")

            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@deptId", Me.DeptID1)
            cmd.Parameters.AddWithValue("@deptName", Me.DeptName1)

            cmd.ExecuteNonQuery()
            tran.Commit()

            conn.Close()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("Error occured: Could not insert record: " & ex.Message)
            Return 0
        End Try

        Return 1
    End Function

    Public Overloads Function update(_deptId As Integer) As Integer

        Dim conn = New Db().getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("UPDATE " & tableName & " ")
            sql.Append("SET ")

            sql.Append("DEPT_ID=@deptId,")
            sql.Append("DEPT_NAME=@deptName")

            sql.Append(" WHERE DEPT_ID=@_deptId")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@deptId", Me.DeptID1)
            cmd.Parameters.AddWithValue("@deptName", Me.DeptName1)
            cmd.Parameters.AddWithValue("@_deptId", _deptId)

            cmd.ExecuteNonQuery()
            tran.Commit()

            conn.Close()

        Catch ex As Exception
            tran.Rollback()
            MsgBox("Error occured: Could not update record: " & ex.Message)
            Return 0
        End Try

        Return 1
    End Function

    Public Overloads Function delete() As Integer

        Dim conn = New Db().getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("DELETE FROM " & tableName & " ")
            sql.Append(" WHERE DEPT_ID=@deptId")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@deptId", DeptID1)
            cmd.ExecuteNonQuery()


            tran.Commit()
            conn.Close()

        Catch ex As Exception
            tran.Rollback()
            MsgBox("Error occured: Could not update record: " & ex.Message)
            Return 0
        End Try

        Return 1
    End Function

    Public Overloads Function all() As BindingSource

        Dim bs1 As New BindingSource
        Try
            Dim conn = New Db().getMySqlConnection

            Dim sql As StringBuilder = New StringBuilder
            sql.Append("SELECT a.DEPT_ID, a.DEPT_NAME FROM " & tableName & " a ")
            sql.Append(" ORDER BY a.DEPT_NAME asc")

            Dim da As New MySqlDataAdapter(sql.ToString, conn)
            Dim ds As DataSet = New DataSet
            da.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function

    Public Function lookUpDepartment() As BindingSource

        Dim prodId As Integer = 0
        Dim bs1 As New BindingSource
        Try
            Dim conn As MySqlConnection = db.getMySqlConnection()
            Dim Str As String = "SELECT * FROM " & tableName
            Dim Search As New MySqlDataAdapter(Str, conn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function

End Class
