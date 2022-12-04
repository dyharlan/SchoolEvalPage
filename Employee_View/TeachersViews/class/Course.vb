Imports MySql.Data.MySqlClient
Imports System.Text

Public Class Course
    Private courseCode As Integer
    Private courseName As String
    Dim db As Db = New Db()
    Private tableName As String = TABLE_COURSE_OFFERINGS

    Public Sub New()
    End Sub

    Public Sub New(courseCode As Integer, courseName As String)
        Me.courseCode = courseCode
        Me.courseName = courseName
    End Sub

    Public Property CourseCode1 As Integer
        Get
            Return courseCode
        End Get
        Set(value As Integer)
            courseCode = value
        End Set
    End Property

    Public Property CourseName1 As String
        Get
            Return courseName
        End Get
        Set(value As String)
            courseName = value
        End Set
    End Property

    Public Overloads Function save() As Integer


        Dim conn As MySqlConnection = Db.getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("INSERT INTO " & tableName & " ")
            sql.Append("(")

            sql.Append("COURSE_CODE,")
            sql.Append("COURSE_NAME")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@courseCode,")
            sql.Append("@courseName")

            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@courseCode", Me.CourseCode1)
            cmd.Parameters.AddWithValue("@courseName", Me.CourseName1)

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

    Public Overloads Function update(_courseCode As Integer) As Integer

        Dim conn = New Db().getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("UPDATE " & tableName & " ")
            sql.Append("SET ")

            sql.Append("COURSE_CODE=@courseCode,")
            sql.Append("COURSE_NAME=@courseName")

            sql.Append(" WHERE COURSE_CODE=@_courseCode")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@courseCode", Me.CourseCode1)
            cmd.Parameters.AddWithValue("@courseName", Me.CourseName1)
            cmd.Parameters.AddWithValue("@_courseCode", _courseCode)

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
            cmd.Parameters.AddWithValue("@courseCode", CourseCode1)
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
            sql.Append("SELECT a.COURSE_CODE, a.COURSE_NAME FROM " & tableName & " a ")
            sql.Append(" ORDER BY a.COURSE_NAME asc")

            Dim da As New MySqlDataAdapter(sql.ToString, conn)
            Dim ds As DataSet = New DataSet
            da.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function

    Public Function lookUpCourse() As BindingSource

        Dim bs1 As New BindingSource
        Try
            Dim conn As MySqlConnection = db.getMySqlConnection()
            Dim Str As String = "SELECT COURSE_CODE,COURSE_NAME FROM " & tableName
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
