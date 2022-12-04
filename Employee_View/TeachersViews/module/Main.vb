Module Main

    Public DATABASE_NAME As String = "evaluation"
    Public SERVER_NAME As String = "server=localhost;user=root;password=;database=" & DATABASE_NAME & ";port=3310;"

    Public Const TABLE_PERSONS = "persons"
    Public Const TABLE_STUDENTS = "students"
    Public Const TABLE_DEPARTMENTS = "departments"
    Public Const TABLE_TEACHERS = "teachers"
    Public Const TABLE_COURSE_OFFERINGS = "course_offerings"
    Public Const TABLE_COURSE_ASSIGNMENTS = "course_assignments"
    Public Const TABLE_CLASSES = "classes"
    Public Const TABLE_CLASS_STUDENT_LIST = "class_student_lists"
    Public Const TABLE_EVAL_STATUS = "eval_status"
    Public Const TABLE_FORMS = "forms"
    Public Const TABLE_PERSON_ROLE = "person_roles"
    Public Const TABLE_PERSON_STATUS = "person_status"
    Public CURRENT_ROLE As Integer = 0
    Public CURRENT_USER As String = Nothing
    Public CURRENT_TEACHER_CODE As Integer = 0
    Public CONN_STATUS As Boolean = False


    Public Enum PERSON_ROLE
        student = 1
        teacher = 2
        admin = 3
    End Enum
    Public Sub Main()

        Dim login As New LogIn
        login.Show()
    End Sub

    Public Enum SERVER_STATE
        CONNECTED = True
        DISCONNECTED = False
    End Enum
    Public Function isStudentTeacherNumValid(num As String) As Boolean

        'Try
        '    Dim yr As String = Now.Year.ToString
        '    Dim curYr = num.Substring(0, yr.Length)
        '    Return yr = curYr
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Return True

    End Function

End Module
