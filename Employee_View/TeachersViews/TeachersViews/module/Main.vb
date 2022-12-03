Module Main

    Public SERVER_NAME As String = "server=localhost;user=root;password=Ralph2004!;database=" & DATABASE_NAME & ";port=3310;"

    Public Const DATABASE_NAME = "evaluation"
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
    Public CURRENT_ROLE As Integer = 0
    Public CURRENT_USER As String = Nothing
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


End Module
