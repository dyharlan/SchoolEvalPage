
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class ClassAssignment


    Private classCode As Integer
    Private studentNumber As Integer
    Dim db As Db = New Db()
    Private tableName As String = TABLE_CLASS_STUDENT_LIST

    Public Sub New()
    End Sub

    Public Sub New(classCode As Integer, studentNumber As Integer)
        Me.classCode = classCode
        Me.studentNumber = studentNumber
    End Sub

    Public Property ClassCode1 As Integer
        Get
            Return classCode
        End Get
        Set(value As Integer)
            classCode = value
        End Set
    End Property

    Public Property StudentNumber1 As Integer
        Get
            Return studentNumber
        End Get
        Set(value As Integer)
            studentNumber = value
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

            sql.Append("CLASS_CODE,")
            sql.Append("STU_NUM ")


            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@classCode,")
            sql.Append("@studNum")


            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@classCode", Me.ClassCode1)
            cmd.Parameters.AddWithValue("@studNum", Me.StudentNumber1)


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

    Public Overloads Function all() As BindingSource


        Dim bs1 As New BindingSource
        Try
            Dim conn = New Db().getMySqlConnection

            Dim sql As StringBuilder = New StringBuilder
            sql.Append("SELECT b.CLASS_CODE,a.STU_NUM, b.CLASS_NAME,concat(f.LNAME,',',f.FNAME) AS STUDENT, concat(d.LNAME,',',d.FNAME) AS ASSIGNED_TEACHER FROM " & tableName & " a ")
            sql.Append(" JOIN " & TABLE_CLASSES & " b ON b.CLASS_CODE=a.CLASS_CODE")
            sql.Append(" JOIN " & TABLE_TEACHERS & " c ON c.TEACHERS_CODE=b.TEACHERS_CODE")
            sql.Append(" JOIN " & TABLE_PERSONS & " d ON d.PERSON_ID=c.PERSON_ID")
            sql.Append(" JOIN " & TABLE_STUDENTS & " e ON e.STU_NUM=a.STU_NUM")
            sql.Append(" JOIN " & TABLE_PERSONS & " f ON F.PERSON_ID=e.PERSON_ID")
            sql.Append(" ORDER BY b.CLASS_NAME asc")

            Dim da As New MySqlDataAdapter(sql.ToString, conn)
            Dim ds As DataSet = New DataSet
            da.Fill(ds, tableName)
            bs1.DataSource = ds.Tables(tableName)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return bs1

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
            sql.Append(" AND STU_NUM=@stuNum")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@classCode", Me.classCode)
            cmd.Parameters.AddWithValue("@stuNum", Me.studentNumber)
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
End Class
