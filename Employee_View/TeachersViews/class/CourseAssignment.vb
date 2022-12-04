Imports MySql.Data.MySqlClient
Imports System.Text

Public Class CourseAssignment

    Private courseCode As Integer
    Private teacherCode As Integer
    Private classCode As Integer
    Dim db As Db = New Db()
    Private tableName As String = TABLE_COURSE_ASSIGNMENTS


    Public Sub New()
    End Sub

    Public Sub New(courseCode As Integer, teacherCode As Integer, classCode As Integer)
        Me.courseCode = courseCode
        Me.teacherCode = teacherCode
        Me.classCode = classCode
    End Sub

    Public Property CourseCode1 As Integer
        Get
            Return courseCode
        End Get
        Set(value As Integer)
            courseCode = value
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

    Public Property ClassCode1 As Integer
        Get
            Return classCode
        End Get
        Set(value As Integer)
            classCode = value
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

            sql.Append("CLASS_CODE,")
            sql.Append("COURSE_CODE,")
            sql.Append("TEACHERS_CODE ")


            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@classCode,")
            sql.Append("@courseCode,")
            sql.Append("@teacherCode")

            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@classCode", Me.ClassCode1)
            cmd.Parameters.AddWithValue("@courseCode", Me.CourseCode1)
            cmd.Parameters.AddWithValue("@teacherCode", Me.TeacherCode1)


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
            sql.Append(" AND COURSE_CODE=@courseCode")
            sql.Append(" AND TEACHERS_CODE=@teacherCode")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@classCode", Me.classCode)
            cmd.Parameters.AddWithValue("@courseCode", Me.courseCode)
            cmd.Parameters.AddWithValue("@teacherCode", Me.teacherCode)
            cmd.ExecuteNonQuery()

            tran.Commit()
            conn.Close()

        Catch ex As Exception
            tran.Rollback()
            MsgBox("Error occured: Could not delete record: " & ex.Message)
            Return 0
        End Try

        Return 1
    End Function

    Public Overloads Function all() As BindingSource


        Dim bs1 As New BindingSource
        Try
            Dim conn = New Db().getMySqlConnection

            Dim sql As StringBuilder = New StringBuilder
            sql.Append("SELECT a.CLASS_CODE,a.TEACHERS_CODE,a.COURSE_CODE, b.CLASS_NAME, concat(d.LNAME,',',d.FNAME) AS TEACHER, e.COURSE_NAME FROM " & tableName & " a ")
            sql.Append(" JOIN " & TABLE_CLASSES & " b ON b.CLASS_CODE=a.CLASS_CODE")
            sql.Append(" JOIN " & TABLE_TEACHERS & " c ON c.TEACHERS_CODE=b.TEACHERS_CODE")
            sql.Append(" JOIN " & TABLE_PERSONS & " d ON d.PERSON_ID=c.PERSON_ID")
            sql.Append(" JOIN " & TABLE_COURSE_OFFERINGS & " e ON e.COURSE_CODE=a.COURSE_CODE")
            If CURRENT_ROLE = PERSON_ROLE.teacher Then
                sql.Append(" WHERE c.TEACHERS_CODE ='" & CURRENT_TEACHER_CODE & "' ")
            End If
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

End Class
