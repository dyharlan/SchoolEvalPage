Imports MySql.Data.MySqlClient
Imports System.Text

Public Class Student
    Inherits Person

    Private stuNum As Integer

    Dim db As Db = New Db()
    Private tableName As String = TABLE_STUDENTS

    Public Sub New()
    End Sub

    Public Sub New(stuNum As Integer)
        Me.stuNum = stuNum

    End Sub

    Public Property StuNum1 As Integer
        Get
            Return stuNum
        End Get
        Set(value As Integer)
            stuNum = value
        End Set
    End Property


    Public Function isStudentNumExist(studentNum As Integer) As Boolean

        Dim rd As MySqlDataReader
        Dim cmd As New MySqlCommand
        Dim conn As MySqlConnection = db.getMySqlConnection()
        cmd.CommandText = "Select PERSON_ID,STU_NUM from " & tableName & " where STU_NUM ='" & studentNum & "'"
        cmd.Connection = conn
        rd = cmd.ExecuteReader

        If rd.Read Then
            PersonId1 = rd.GetInt32(0)
            StuNum1 = rd.GetString(1)

        End If
        rd.Close()

        If StuNum1 = Nothing Then
            Return False
        Else
            Return True
        End If

    End Function


    Public Overloads Function save() As Integer


        Dim conn As MySqlConnection = db.getMySqlConnection()
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
            sql.Append("STU_NUM")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@personId,")
            sql.Append("@studNum")

            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@personId", Me.PersonId1)
            cmd.Parameters.AddWithValue("@studNum", Me.StuNum1)

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
            Return 0
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("UPDATE " & tableName & " ")
            sql.Append("SET ")

            ' sql.Append("PERSON_ID=@personId,")
            sql.Append("STU_NUM=@studNum")

            sql.Append(" WHERE PERSON_ID=@_personId")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            '  cmd.Parameters.AddWithValue("@personId", Me.PersonId1)
            cmd.Parameters.AddWithValue("@studNum", Me.StuNum1)
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

    Public Overloads Function all() As BindingSource

        Dim bs1 As New BindingSource
        Try
            Dim conn = New Db().getMySqlConnection

            Dim sql As StringBuilder = New StringBuilder
            sql.Append("SELECT a.PERSON_ID,a.LNAME,a.MNAME,a.FNAME,b.STU_NUM,a.DOB,a.YR_START FROM " & tableName & " b ")
            sql.Append("JOIN " & TABLE_PERSONS & " a ON a.PERSON_ID=b.PERSON_ID")
            sql.Append(" WHERE STATUS_CODE=1 ")
            sql.Append(" ORDER BY a.LNAME asc")

            Dim da As New MySqlDataAdapter(sql.ToString, conn)
            Dim ds As DataSet = New DataSet
            da.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function

    Public Function lookUpStudent() As BindingSource

        Dim prodId As Integer = 0
        Dim bs1 As New BindingSource
        Try
            Dim conn As MySqlConnection = db.getMySqlConnection()
            Dim Str As String = "SELECT a.STU_NUM,concat(b.LNAME,',',b.FNAME) AS STUDENT_NAME FROM " & tableName & " a JOIN " & TABLE_PERSONS & " b on b.PERSON_ID=a.PERSON_ID WHERE b.STATUS_CODE=1"
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
