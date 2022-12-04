Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1.X509.SigI
Imports Org.BouncyCastle.Bcpg

Public Class Db



    'Public SERVER_NAME As String = "server=localhost;user=root;database=" & DATABASE_NAME & ";port=3306;password=;"

    ' Dim server As String = "server=localhost;user=root;password=Ralph2004!;port=3310;database=evaluation"
    'Dim server As String = "server=localhost;user=root;database=test;port=3306;password=;"
    'Public SERVER_NAME As String = "server=localhost;user=root;database=" & DATABASE_NAME & ";port=3306;password=;"
    Public dbaseFlag As Integer = dbaseFlagType.operation


    Public Enum dbaseFlagType

        initialize = 1
        operation = 2

    End Enum
    Public Function getMySqlConnection() As MySqlConnection

        Dim conn As New MySql.Data.MySqlClient.MySqlConnection

        Try
            conn.ConnectionString = SERVER_NAME
            conn.Open()
            CONN_STATUS = SERVER_STATE.CONNECTED
        Catch ex As MySql.Data.MySqlClient.MySqlException
            CONN_STATUS = SERVER_STATE.DISCONNECTED
            Using form = New Form() With {.TopMost = True}
                MessageBox.Show(form, ex.Message, "Database Server Connection Error")
            End Using
        End Try

        Return conn
    End Function

    Public Function prepareDatabase() As Integer

        If dbaseFlag = dbaseFlagType.operation Then
            Return 1
        End If

        Dim conn As MySqlConnection = getMySqlConnection()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        dropDatabase(conn)
        Dim result As Integer = createDatabase(conn)

        Select Case result
            Case 1
                createTables(conn)
            Case 1007
        End Select



    End Function
    Function createTables(conn As MySqlConnection)
        cteateTable_PersonRole(conn)
        cteateTable_PersonStatus(conn)
        cteateTable_Person(conn) '1050 -> table exist
        cteateTable_Student(conn)
        cteateTable_Department(conn)
        cteateTable_Teacher(conn)
        cteateTable_CourseOfferings(conn)
        cteateTable_CoursesAssignment(conn)
        cteateTable_Classes(conn)
        cteateTable_ClassesAssignment(conn)
        cteateTable_EvalStatus(conn)
        cteateTable_Form(conn)
    End Function
    Function createDatabase(conn As MySqlConnection) As Integer
        DATABASE_NAME = "evaluation"
        Dim sql As String = "CREATE database " & DATABASE_NAME
        Dim cmd As New MySqlCommand(sql, conn)

        Try
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            ' MsgBox(ex.Message)
            Return ex.Number
        End Try
    End Function
    Function dropDatabase(conn As MySqlConnection)

        Dim sql As String = " DROP DATABASE " & DATABASE_NAME & ";"
        Dim cmd As New MySqlCommand(sql, conn)

        Try
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            ' MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function
    Function dropTable(databaseName As String, tableName As String, conn As MySqlConnection)

        Dim sql As StringBuilder = New StringBuilder()

        sql.Append("USE " & DATABASE_NAME & "; ")
        sql.Append(" DROP TABLE " & tableName & ";")
        Try
            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try
    End Function

    Function cteateTable_PersonStatus(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()


            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_PERSON_STATUS & " ")
            sql.Append("(")

            sql.Append("STATUS_CODE INT Not NULL,")
            sql.Append("STATUS_NAME VARCHAR(50) NOT NULL,")
            sql.Append("PRIMARY KEY (STATUS_CODE)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Dim result As Integer = cmd.ExecuteNonQuery()
            insertPersonStatus(1, "Active")
            insertPersonStatus(2, "InActive")



            Return result
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function
    Function cteateTable_PersonRole(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()


            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_PERSON_ROLE & " ")
            sql.Append("(")

            sql.Append("ROLE_CODE INT Not NULL,")
            sql.Append("ROLE_NAME VARCHAR(50) NOT NULL,")
            sql.Append("PRIMARY KEY (ROLE_CODE)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Dim result As Integer = cmd.ExecuteNonQuery()
            insertPersonRole(1, "Student")
            insertPersonRole(2, "Teacher")
            insertPersonRole(3, "Admin")


            Return result
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function
    Function insertPersonRole(roleCode As Integer, roleName As String)

        Dim conn As MySqlConnection = getMySqlConnection()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim tran As MySqlTransaction = conn.BeginTransaction


        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("USE evaluation ; INSERT INTO " & TABLE_PERSON_ROLE & " ")
            sql.Append("(")

            sql.Append("ROLE_CODE,")
            sql.Append("ROLE_NAME")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@roleCode,")
            sql.Append("@roleName")

            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@roleCode", roleCode)
            cmd.Parameters.AddWithValue("@roleName", roleName)

            cmd.ExecuteNonQuery()
            tran.Commit()

            conn.Close()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("Error occured: Could not insert record: " & ex.Message)
            Return 0
        End Try
    End Function

    Function insertPersonStatus(statusCode As Integer, statusName As String)

        Dim conn As MySqlConnection = getMySqlConnection()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim tran As MySqlTransaction = conn.BeginTransaction


        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("USE evaluation ; INSERT INTO " & TABLE_PERSON_STATUS & " ")
            sql.Append("(")

            sql.Append("STATUS_CODE,")
            sql.Append("STATUS_NAME")

            sql.Append(")")
            sql.Append("VALUES")
            sql.Append("(")

            sql.Append("@statusCode,")
            sql.Append("@statusName")

            sql.Append(");")

            Dim cmd As New MySqlCommand
            cmd.Transaction = tran
            cmd.Connection = conn
            cmd.CommandText = sql.ToString
            cmd.Parameters.AddWithValue("@statusCode", statusCode)
            cmd.Parameters.AddWithValue("@statusName", statusName)

            cmd.ExecuteNonQuery()
            tran.Commit()

            conn.Close()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("Error occured: Could not insert record: " & ex.Message)
            Return 0
        End Try
    End Function

    Function cteateTable_Person(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()

            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_PERSONS & " ")
            sql.Append("(")

            sql.Append("PERSON_ID INT NOT NULL AUTO_INCREMENT,")
            sql.Append("FNAME VARCHAR(35) NOT NULL,")
            sql.Append("MNAME VARCHAR(25),")
            sql.Append("LNAME VARCHAR(30) NOT NULL,")
            sql.Append("DOB DATE NOT NULL,")
            sql.Append("ROLE_CODE INT NOT NULL, ")
            sql.Append("YR_START INT NOT NULL,")
            sql.Append("STATUS_CODE INT NOT NULL DEFAULT '1', ")
            sql.Append("PRIMARY KEY (PERSON_ID),")
            sql.Append("FOREIGN KEY(ROLE_CODE) REFERENCES " & TABLE_PERSON_ROLE & " (ROLE_CODE),")
            sql.Append("FOREIGN KEY(STATUS_CODE) REFERENCES " & TABLE_PERSON_STATUS & " (STATUS_CODE),")
            sql.Append("UNIQUE(FNAME,MNAME,LNAME)")


            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function


    Function cteateTable_Student(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()


            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_STUDENTS & " ")
            sql.Append("(")

            sql.Append("PERSON_ID INT NOT NULL,")
            sql.Append("STU_NUM INT NOT NULL UNIQUE,")
            sql.Append("FOREIGN KEY(PERSON_ID) REFERENCES " & TABLE_PERSONS & " (PERSON_ID),")
            sql.Append("PRIMARY KEY(STU_NUM, PERSON_ID)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function

    Function cteateTable_Department(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()


            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_DEPARTMENTS & " ")
            sql.Append("(")

            sql.Append("DEPT_ID INT Not NULL,")
            sql.Append("DEPT_NAME VARCHAR(50) Not NULL,")
            sql.Append("PRIMARY KEY(DEPT_ID)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function

    Function cteateTable_Teacher(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()


            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_TEACHERS & " ")
            sql.Append("(")

            sql.Append("PERSON_ID INT Not NULL,")
            sql.Append("TEACHERS_CODE INT Not NULL UNIQUE,")
            sql.Append("DEPT_ID INT Not NULL,")
            sql.Append("FOREIGN KEY(PERSON_ID) REFERENCES " & TABLE_PERSONS & "(PERSON_ID),")
            sql.Append("FOREIGN KEY(DEPT_ID) REFERENCES " & TABLE_DEPARTMENTS & "(DEPT_ID),")
            sql.Append("PRIMARY KEY(TEACHERS_CODE, PERSON_ID)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function

    Function cteateTable_CourseOfferings(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()

            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_COURSE_OFFERINGS & " ")
            sql.Append("(")

            sql.Append("COURSE_CODE INT Not NULL,")
            sql.Append("COURSE_NAME VARCHAR(50) Not NULL,")
            sql.Append("PRIMARY KEY(COURSE_CODE)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function


    Function cteateTable_CoursesAssignment(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()

            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_COURSE_ASSIGNMENTS & " ")
            sql.Append("(")

            sql.Append("COURSE_CODE INT Not NULL,")
            sql.Append("TEACHERS_CODE INT Not NULL,")
            sql.Append("CLASS_CODE INT Not NULL,")
            sql.Append("FOREIGN KEY(TEACHERS_CODE) REFERENCES " & TABLE_TEACHERS & "(TEACHERS_CODE),")
            sql.Append("FOREIGN KEY(COURSE_CODE) REFERENCES " & TABLE_COURSE_OFFERINGS & "(COURSE_CODE),")
            sql.Append("UNIQUE(COURSE_CODE, CLASS_CODE)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function

    Function cteateTable_Classes(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()

            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_CLASSES & " ")
            sql.Append("(")

            sql.Append("CLASS_CODE INT Not NULL,")
            sql.Append("CLASS_NAME VARCHAR(50) Not NULL,")
            sql.Append("TEACHERS_CODE INT Not NULL,")
            sql.Append("FOREIGN KEY(TEACHERS_CODE) REFERENCES " & TABLE_TEACHERS & "(TEACHERS_CODE),")
            sql.Append("PRIMARY KEY(CLASS_CODE)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function

    Function cteateTable_ClassesAssignment(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()

            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_CLASS_STUDENT_LIST & " ")
            sql.Append("(")

            sql.Append("CLASS_CODE INT Not NULL ,")
            sql.Append("STU_NUM Int Not NULL UNIQUE KEY,")
            sql.Append("FOREIGN KEY(CLASS_CODE) REFERENCES " & TABLE_CLASSES & "(CLASS_CODE),")
            sql.Append("FOREIGN KEY(STU_NUM) REFERENCES " & TABLE_STUDENTS & "(STU_NUM)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function

    Function cteateTable_EvalStatus(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()


            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_EVAL_STATUS & " ")
            sql.Append("(")

            sql.Append("STU_NUM INT Not NULL,")
            sql.Append("TEACHERS_CODE INT Not NULL,")
            sql.Append("COURSE_CODE INT NOT NULL,")
            sql.Append("EVAL_DATE DATE Not NULL,")
            sql.Append("FORM_CODE VARCHAR(128) Not NULL UNIQUE KEY,")
            sql.Append("FOREIGN KEY(STU_NUM) REFERENCES " & TABLE_STUDENTS & "(STU_NUM),")
            sql.Append("FOREIGN KEY(TEACHERS_CODE) REFERENCES " & TABLE_TEACHERS & "(TEACHERS_CODE),")
            sql.Append("UNIQUE(STU_NUM, COURSE_CODE)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function

    Function cteateTable_Form(conn As MySqlConnection)

        Try
            Dim sql As StringBuilder = New StringBuilder()


            sql.Append("USE " & DATABASE_NAME & "; ")
            sql.Append("CREATE TABLE " & TABLE_FORMS & " ")
            sql.Append("(")

            sql.Append("FORM_CODE VARCHAR(128) NOT NULL UNIQUE,")
            sql.Append("TEACHERS_CODE INT Not NULL,")
            sql.Append("Q1_SCORE INT NOT NULL,")
            sql.Append("Q2_SCORE INT NOT NULL,")
            sql.Append("Q3_SCORE INT NOT NULL,")
            sql.Append("Q4_SCORE INT NOT NULL,")
            sql.Append("Q5_SCORE INT NOT NULL,")
            sql.Append("Q6_SCORE INT NOT NULL,")
            sql.Append("Q7_SCORE INT NOT NULL,")
            sql.Append("Q8_SCORE INT NOT NULL,")
            sql.Append("Q9_SCORE INT NOT NULL,")
            sql.Append("Q10_SCORE INT NOT NULL,")
            sql.Append("FOREIGN KEY(FORM_CODE) REFERENCES " & TABLE_EVAL_STATUS & " (FORM_CODE) ON DELETE CASCADE,")
            sql.Append("FOREIGN KEY(TEACHERS_CODE) REFERENCES " & TABLE_TEACHERS & "(TEACHERS_CODE) ON DELETE CASCADE,")
            sql.Append("UNIQUE(FORM_CODE, TEACHERS_CODE)")

            sql.Append(");")

            Dim cmd As New MySqlCommand(sql.ToString, conn)
            Return cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return ex.Number
        End Try

    End Function





End Class
