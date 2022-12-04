Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Windows.Forms
Imports System.Text

Public Class Person

    Private personId As Integer
    Private firstName As String
    Private middleName As String
    Private lastName As String
    Private dob As Date
    Private yrStart As Integer
    Private roleCode As Integer
    Private statusCode As Integer
    Dim db As Db = New Db()
    Private tableName As String = TABLE_PERSONS

    Public Sub New()

    End Sub

    Public Sub New(personId As Integer, firstName As String, middleName As String, lastName As String, dob As Date, roleCode As Integer)
        Me.personId = personId
        Me.firstName = firstName
        Me.middleName = middleName
        Me.lastName = lastName
        Me.dob = dob
        Me.yrStart = yrStart
        Me.roleCode = roleCode
    End Sub

    Public Property PersonId1 As Integer
        Get
            Return personId
        End Get
        Set(value As Integer)
            personId = value
        End Set
    End Property

    Public Property FirstName1 As String
        Get
            Return firstName
        End Get
        Set(value As String)
            firstName = value
        End Set
    End Property

    Public Property MiddleName1 As String
        Get
            Return middleName
        End Get
        Set(value As String)
            middleName = value
        End Set
    End Property

    Public Property LastName1 As String
        Get
            Return lastName
        End Get
        Set(value As String)
            lastName = value
        End Set
    End Property

    Public Property Dob1 As Date
        Get
            Return dob
        End Get
        Set(value As Date)
            dob = value
        End Set
    End Property

    Public Property yrStart1 As Integer
        Get
            Return yrStart
        End Get
        Set(value As Integer)
            yrStart = value
        End Set
    End Property

    Public Property RoleCode1 As Integer
        Get
            Return roleCode
        End Get
        Set(value As Integer)
            roleCode = value
        End Set
    End Property

    Public Property StatusCode1 As Integer
        Get
            Return statusCode
        End Get
        Set(value As Integer)
            statusCode = value
        End Set
    End Property

    Public Function save(conn As MySqlConnection) As Integer



        If countPersonByFullName() > 0 Then
            MsgBox("Person is already in the list.")
            Return Nothing
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("INSERT INTO " & tableName & " ")
            sql.Append("(")

            '  sql.Append("PERSON_ID,")
            sql.Append("FNAME,")
            sql.Append("MNAME,")
            sql.Append("LNAME,")
            sql.Append("DOB,")
            sql.Append("YR_START,")
            sql.Append("ROLE_CODE")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            ' sql.Append("@personId,")
            sql.Append("@fname,")
            sql.Append("@mname,")
            sql.Append("@lname,")
            sql.Append("@dob,")
            sql.Append("@yrStart,")
            sql.Append("@roleCode")

            sql.Append(");SELECT LAST_INSERT_ID()")

            Dim sqlCommand As New MySqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = sql.ToString

            sqlCommand.Parameters.AddWithValue("@fname", Me.FirstName1)
            sqlCommand.Parameters.AddWithValue("@mname", Me.MiddleName1)
            sqlCommand.Parameters.AddWithValue("@lname", Me.LastName1)
            sqlCommand.Parameters.AddWithValue("@dob", Me.dob)
            sqlCommand.Parameters.AddWithValue("@yrStart", Me.yrStart1)
            sqlCommand.Parameters.AddWithValue("@roleCode", Me.RoleCode1)

            Me.PersonId1 = sqlCommand.ExecuteScalar()

        Catch ex As MySqlException
            MsgBox("Error occured: Could not insert record: " & ex.Message, MsgBoxStyle.Critical)
            Return 0
        End Try

        Return 1
    End Function

    Public Function update(_personId As Integer, conn As MySqlConnection) As Integer

        If countPersonByFullName() > 1 Then
            MsgBox("Person is already in the list.")
            Return 0
        End If

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("UPDATE " & tableName & " ")
            sql.Append("SET ")

            ' sql.Append("PERSON_ID=@personId,")
            sql.Append("FNAME=@fname,")
            sql.Append("MNAME=@mname,")
            sql.Append("LNAME=@lname,")
            sql.Append("DOB=@dob,")
            sql.Append("YR_START=@yrStart")
            'sql.Append("ROLE_CODE=@roleCode")

            sql.Append(" WHERE PERSON_ID=@_personId")

            Dim sqlCommand As New MySqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = sql.ToString
            ' sqlCommand.Parameters.AddWithValue("@personId", Me.personId)
            sqlCommand.Parameters.AddWithValue("@fname", Me.firstName)
            sqlCommand.Parameters.AddWithValue("@mname", Me.middleName)
            sqlCommand.Parameters.AddWithValue("@lname", Me.lastName)
            sqlCommand.Parameters.AddWithValue("@dob", Me.dob)
            sqlCommand.Parameters.AddWithValue("@yrStart", Me.yrStart)
            'sqlCommand.Parameters.AddWithValue("@roleCode", Me.RoleCode1)
            sqlCommand.Parameters.AddWithValue("@_personId", _personId)

            sqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Error occured: Could not update record: " & ex.Message, MsgBoxStyle.Critical)
            Return 0
        End Try

        Return 1
    End Function

    Public Function updateStatus(_personId As Integer, statusCode As Integer) As Integer


        Dim conn As MySqlConnection = db.getMySqlConnection()
        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("UPDATE " & tableName & " ")
            sql.Append("SET ")

            sql.Append("STATUS_CODE=@status_code ")
            sql.Append(" WHERE PERSON_ID=@_personId")

            Dim sqlCommand As New MySqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = sql.ToString

            sqlCommand.Parameters.AddWithValue("@status_code", statusCode)
            sqlCommand.Parameters.AddWithValue("@_personId", _personId)

            sqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Error occured: Could not update record: " & ex.Message, MsgBoxStyle.Critical)
            Return 0
        End Try

        Return 1
    End Function


    Public Function delete(conn As MySqlConnection) As Integer

        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("DELETE FROM " & tableName & " ")
            sql.Append(" WHERE PERSON_ID=@personId")

            Dim sqlCommand As New MySqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = sql.ToString
            sqlCommand.Parameters.AddWithValue("@personId", Me.personId)
            sqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("Error occured: Could not update record: " & ex.Message, MsgBoxStyle.Critical)
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
            sql.Append("SELECT a.PERSON_ID,a.LNAME,a.MNAME,a.FNAME FROM " & tableName & " a ")
            sql.Append(" ORDER BY a.LNAME asc")


            Dim Search As New MySqlDataAdapter(sql.ToString, conn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

    End Function

    Function countPersonByFullName() As Integer

        Dim totalRows = 0
        Try

            Dim conn = New Db().getMySqlConnection
            Dim rd As MySqlDataReader
            Dim cmd As New MySqlCommand
            Dim sql As StringBuilder = New StringBuilder()

            sql.Append("SELECT COUNT(*) from ")
            sql.Append(tableName)
            sql.Append(" WHERE FNAME='" & firstName & "'")
            sql.Append(" AND LNAME='" & lastName & "'")
            sql.Append(" AND MNAME='" & middleName & "'")

            cmd.CommandText = sql.ToString
            cmd.Connection = conn
            totalRows = cmd.ExecuteScalar()
            rd = cmd.ExecuteReader

            rd.Close()
            conn.Close()

        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try

        Return totalRows
    End Function


    Sub check()
        MsgBox("person check")
    End Sub

End Class




