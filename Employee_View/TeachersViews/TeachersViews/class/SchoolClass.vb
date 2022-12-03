Imports MySql.Data.MySqlClient
Imports System.Text

Public Class SchoolClass
    Private classCode As Integer
    Private className As String
    Private teacherCode As Integer
    Dim db As Db = New Db()
    Private tableName As String = TABLE_CLASSES
    Public Sub New()
    End Sub

    Public Sub New(classCode As Integer, className As String, teacherCode As Integer, classCode1 As Integer, className1 As String, teacherCode1 As Integer)
        Me.classCode = classCode
        Me.className = className
        Me.teacherCode = teacherCode
        Me.ClassCode1 = classCode1
        Me.ClassName1 = className1
        Me.TeacherCode1 = teacherCode1
    End Sub

    Public Property ClassCode1 As Integer
        Get
            Return classCode
        End Get
        Set(value As Integer)
            classCode = value
        End Set
    End Property

    Public Property ClassName1 As String
        Get
            Return className
        End Get
        Set(value As String)
            className = value
        End Set
    End Property

    Public Property TeacherCode1 As Integer
        Get
            Return teacherCode
        End Get
        Set(value As Integer)
            teacherCode = value
        End Set
    End Property
    Public Function save() As Integer



        'If countPersonByFullName() > 0 Then
        '    MsgBox("Person is already in the list.")
        '    Return Nothing
        'End If

        Try
            Dim conn = db.getMySqlConnection
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("INSERT INTO " & tableName & " ")
            sql.Append("(")

            sql.Append("CLASS_CODE,")
            sql.Append("CLASS_NAME,")
            sql.Append("TEACHER_CODE")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@classCode,")
            sql.Append("@className,")
            sql.Append("@teacherCode ")


            sql.Append(");")

            Dim sqlCommand As New MySqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = sql.ToString
            sqlCommand.Parameters.AddWithValue("@classCode", Me.ClassCode1)
            sqlCommand.Parameters.AddWithValue("@className", Me.ClassName1)
            sqlCommand.Parameters.AddWithValue("@teacherCode", Me.TeacherCode1)


            sqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Error occured: Could not insert record: " & ex.Message)
            Return 0
        End Try

        Return 1
    End Function
    Public Overloads Function update(_classCode As Integer) As Integer

        Dim conn = New Db().getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If



        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("UPDATE " & tableName & " ")
            sql.Append("SET ")

            sql.Append("CLASS_CODE=@classCode,")
            sql.Append("CLASS_NAME=@className,")
            sql.Append("TEACHER_CODE=@teacherCode")

            sql.Append(" WHERE CLASS_CODE=@_classCode")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@classCode", Me.ClassCode1)
            cmd.Parameters.AddWithValue("@className", Me.ClassName1)
            cmd.Parameters.AddWithValue("@teacherCode", Me.TeacherCode1)
            cmd.Parameters.AddWithValue("@_classCode", _classCode)
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
            sql.Append(" WHERE CLASS_CODE=@classCode")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@classCode", ClassCode1)
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
            sql.Append("SELECT a.CLASS_CODE,a.CLASS_NAME,a.TEACHER_CODE,concat(c.LNAME,',',c.FNAME) AS ASSIGNED_TEACHER FROM " & tableName & " a ")
            sql.Append(" JOIN " & TABLE_TEACHERS & " b ON b.TEACHER_CODE=a.TEACHER_CODE")
            sql.Append(" JOIN " & TABLE_PERSONS & " c ON c.PERSON_ID=b.PERSON_ID")
            sql.Append(" ORDER BY a.CLASS_NAME asc")

            Dim da As New MySqlDataAdapter(sql.ToString, conn)
            Dim ds As DataSet = New DataSet
            da.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function
    Public Function lookUpClass() As BindingSource

        Dim prodId As Integer = 0
        Dim bs1 As New BindingSource
        Try
            Dim conn As MySqlConnection = db.getMySqlConnection()
            Dim Str As String = "SELECT a.CLASS_CODE,a.CLASS_NAME FROM " & tableName & " a"
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
