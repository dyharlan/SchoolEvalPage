Imports System.Runtime.CompilerServices
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Windows.Forms
Imports System.Text

Public Class Teacher
    Inherits Person

    Private id As Integer
    Private teacherCode As Integer
    Private deptId As Integer
    Private tableName As String = TABLE_TEACHERS
    Dim db As Db = New Db()

    Public Sub New()
    End Sub

    Public Sub New(id As Integer, teacherCode As Integer, deptId As Integer)
        Me.Id1 = id
        Me.TeacherCode1 = teacherCode
        Me.DeptId1 = deptId
    End Sub

    Public Property Id1 As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
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

    Public Property DeptId1 As Integer
        Get
            Return deptId
        End Get
        Set(value As Integer)
            deptId = value
        End Set
    End Property

    Public Function ToString() As String
        Return TeacherCode1
    End Function

    Public Function isTeacherCodeExist(teacherCode As Integer) As Boolean

        Dim rd As MySqlDataReader
        Dim cmd As New MySqlCommand
        Dim conn As MySqlConnection = db.getMySqlConnection()
        cmd.CommandText = "Select a.PERSON_ID,a.TEACHERS_CODE,a.DEPT_ID,concat(b.LNAME,',',b.FNAME) AS PERSON_NAME from " & tableName & " a JOIN " & TABLE_PERSONS & " b on b.PERSON_ID=a.PERSON_ID where TEACHERS_CODE ='" & teacherCode & "'"
        cmd.Connection = conn
        rd = cmd.ExecuteReader

        If rd.Read Then
            Id1 = rd.GetInt32(0)
            TeacherCode1 = rd.GetString(1)
            Me.DeptId1 = rd.GetInt32(2)
            CURRENT_USER = rd.GetString(3)
        End If
        rd.Close()

        If Id1 = Nothing Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function lookUpTeacher() As BindingSource

        Dim prodId As Integer = 0
        Dim bs1 As New BindingSource
        Try
            Dim conn As MySqlConnection = db.getMySqlConnection()
            Dim Str As String = "SELECT a.TEACHERS_CODE, concat(b.LNAME,',',b.FNAME,' -',a.TEACHERS_CODE) AS TEACHER_NAME FROM " & tableName & " a JOIN " & TABLE_PERSONS & " b ON b.PERSON_ID=a.PERSON_ID b.STATUS_CODE=1"
            Dim Search As New MySqlDataAdapter(Str, conn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function


    Public Overloads Function save() As Integer


        Dim conn As MySqlConnection = Db.getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        If MyBase.save(conn) = 0 Then
            Return 0
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("INSERT INTO " & tableName & " ")
            sql.Append("(")

            sql.Append("PERSON_ID,")
            sql.Append("TEACHERS_CODE,")
            sql.Append("DEPT_ID")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@personId,")
            sql.Append("@teacherCode,")
            sql.Append("@department")

            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@personId", Me.PersonId1)
            cmd.Parameters.AddWithValue("@teacherCode", Me.TeacherCode1)
            cmd.Parameters.AddWithValue("@department", Me.DeptId1)

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

    Public Overloads Function update(_personId As Integer) As Integer

        Dim conn = New Db().getMySqlConnection()
        Dim tran As MySqlTransaction = conn.BeginTransaction

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        If MyBase.update(_personId, conn) = 0 Then
            tran.Rollback()
            conn.Close()
            Return 0
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("UPDATE " & tableName & " ")
            sql.Append("SET ")

            sql.Append("PERSON_ID=@personId,")
            sql.Append("TEACHERS_CODE=@teacherCode,")
            sql.Append("DEPT_ID=@deptId")

            sql.Append(" WHERE PERSON_ID=@_personId")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@personId", _personId)
            cmd.Parameters.AddWithValue("@teacherCode", Me.TeacherCode1)
            cmd.Parameters.AddWithValue("@deptId", Me.DeptId1)
            cmd.Parameters.AddWithValue("@_personId", _personId)

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
            sql.Append(" WHERE PERSON_ID=@personId")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@personId", PersonId1)
            cmd.ExecuteNonQuery()


            If MyBase.delete(conn) = 0 Then
                tran.Rollback()
                Return 0
            End If

            tran.Commit()
            conn.Close()

        Catch ex As Exception
            tran.Rollback()
            MsgBox("Error occured: Could not update record: " & ex.Message)
            Return 0
        End Try

        Return 1
    End Function

    Public Function all() As BindingSource

        Dim prodId As Integer = 0
        Dim bs1 As New BindingSource
        Try
            Dim conn = New Db().getMySqlConnection

            Dim sql As StringBuilder = New StringBuilder
            sql.Append("SELECT a.PERSON_ID,b.LNAME,b.MNAME,b.FNAME,a.TEACHERS_CODE,a.DEPT_ID,b.DOB,c.DEPT_NAME FROM " & tableName & " a ")
            sql.Append("JOIN " & TABLE_PERSONS & " b ON b.PERSON_ID=a.PERSON_ID ")
            sql.Append("JOIN " & TABLE_DEPARTMENTS & " c ON c.DEPT_ID=a.DEPT_ID ")
            sql.Append(" WHERE STATUS_CODE=1 ")
            sql.Append("ORDER BY b.LNAME asc")


            Dim Search As New MySqlDataAdapter(sql.ToString, conn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function

End Class
