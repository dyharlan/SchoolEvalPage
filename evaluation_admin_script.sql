CREATE DATABASE evaluation;

USE evaluation ;

CREATE TABLE person_roles
(ROLE_CODE INT NOT NULL,
ROLE_NAME VARCHAR(30) NOT NULL,
PRIMARY KEY(ROLE_CODE));

CREATE TABLE PERSON_STATUS(
    STATUS_CODE INT NOT NULL KEY,
    STATUS_TYPE VARCHAR(30) NOT NULL
);

INSERT INTO person_roles (ROLE_CODE,ROLE_NAME)VALUES(1,'Student');
INSERT INTO person_roles (ROLE_CODE,ROLE_NAME)VALUES(2,'Teacher');
INSERT INTO person_roles (ROLE_CODE,ROLE_NAME)VALUES(3,'Administrator');

CREATE TABLE persons
(PERSON_ID INT NOT NULL AUTO_INCREMENT,
FNAME VARCHAR(35) NOT NULL,
MNAME VARCHAR(25),
LNAME VARCHAR(30) NOT NULL,
DOB DATE NOT NULL,
ROLE_CODE INT NOT NULL, 
YR_START INT NOT NULL,
STATUS_CODE INT NOT NULL,
PRIMARY KEY (PERSON_ID),
FOREIGN KEY(ROLE_CODE) REFERENCES person_roles (ROLE_CODE),
FOREIGN KEY(STATUS_CODE) REFERENCES PERSON_STATUS(STATUS_CODE),
UNIQUE(FNAME,MNAME,LNAME));

CREATE TABLE students 
(PERSON_ID INT NOT NULL,
STU_NUM INT NOT NULL UNIQUE,
FOREIGN KEY(PERSON_ID) REFERENCES persons (PERSON_ID),
PRIMARY KEY(STU_NUM, PERSON_ID));

CREATE TABLE departments 
(DEPT_ID INT Not NULL,
DEPT_NAME VARCHAR(50) Not NULL,
PRIMARY KEY(DEPT_ID));

CREATE TABLE teachers
(PERSON_ID INT Not NULL,
TEACHERS_CODE INT Not NULL UNIQUE,
DEPT_ID INT Not NULL,
FOREIGN KEY(PERSON_ID) REFERENCES persons(PERSON_ID),
FOREIGN KEY(DEPT_ID) REFERENCES departments(DEPT_ID),
PRIMARY KEY(TEACHERS_CODE, PERSON_ID));

CREATE TABLE course_offerings 
(COURSE_CODE INT Not NULL,
COURSE_NAME VARCHAR(50) Not NULL,
PRIMARY KEY(COURSE_CODE));

CREATE TABLE course_assignments 
(COURSE_CODE INT Not NULL,
TEACHERS_CODE INT Not NULL,
CLASS_CODE INT Not NULL,
FOREIGN KEY(TEACHERS_CODE) REFERENCES teachers(TEACHERS_CODE),
FOREIGN KEY(COURSE_CODE) REFERENCES course_offerings(COURSE_CODE),
UNIQUE(COURSE_CODE, CLASS_CODE));

CREATE TABLE classes 
(CLASS_CODE INT Not NULL,
CLASS_NAME VARCHAR(50) Not NULL,
TEACHERS_CODE INT Not NULL,
FOREIGN KEY(TEACHERS_CODE) REFERENCES teachers(TEACHERS_CODE),
PRIMARY KEY(CLASS_CODE));

CREATE TABLE class_student_lists
(CLASS_CODE INT Not NULL ,
STU_NUM Int Not NULL UNIQUE KEY,
FOREIGN KEY(CLASS_CODE) REFERENCES classes(CLASS_CODE),
FOREIGN KEY(STU_NUM) REFERENCES students(STU_NUM));

CREATE TABLE eval_status
(STU_NUM INT Not NULL,
TEACHERS_CODE INT Not NULL,
COURSE_CODE INT NOT NULL,
EVAL_DATE DATE Not NULL,
FORM_CODE VARCHAR(128) Not NULL UNIQUE KEY,
FOREIGN KEY(STU_NUM) REFERENCES students(STU_NUM),
FOREIGN KEY(TEACHERS_CODE) REFERENCES teachers(TEACHERS_CODE),
UNIQUE(STU_NUM, COURSE_CODE));

CREATE TABLE forms(
    FORM_CODE VARCHAR(128) NOT NULL UNIQUE,
    teachers_CODE INT NOT NULL,
    Q1_SCORE INT NOT NULL,
    Q2_SCORE INT NOT NULL,
    Q3_SCORE INT NOT NULL,
    Q4_SCORE INT NOT NULL,
    Q5_SCORE INT NOT NULL,
    Q6_SCORE INT NOT NULL,
    Q7_SCORE INT NOT NULL,
    Q8_SCORE INT NOT NULL,
    Q9_SCORE INT NOT NULL,
    Q10_SCORE INT NOT NULL,
    FOREIGN KEY (FORM_CODE) REFERENCES eval_status(FORM_CODE) ON DELETE CASCADE,
    FOREIGN KEY (TEACHERS_CODE) REFERENCES teachers(TEACHERS_CODE) ON DELETE CASCADE,
    UNIQUE(FORM_CODE, TEACHERS_CODE)
);

-- Stored Procedures. Execute each procedure from DELIMITER // until end statement
use evaluation;
DELIMITER //
Create Procedure view_unevaluated_teachers(IN stu int)
	Begin
		SELECT persons.fname, persons.lname, course_assignments.teachers_code, course_assignments.course_code, course_offerings.course_name FROM course_assignments 
left join eval_status on course_assignments.teachers_code = eval_status.teachers_code and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_lists where stu_num = stu) 
left join teachers on course_assignments.teachers_code = teachers.teachers_code left join persons on teachers.person_id = persons.person_id
left join course_offerings on course_assignments.course_code = course_offerings.course_code
where class_code = (select class_code from class_student_lists where stu_num = stu) 
and eval_status.teachers_code is null and eval_status.course_code is null order by course_code asc;
    End
DELIMITER ;

DELIMITER //
Create Procedure view_evaluated_teachers(IN stu int)
	Begin
		select persons.fname, persons.lname, eval_status.teachers_code, eval_status.course_code, course_offerings.course_name FROM eval_status left join teachers on eval_status.teachers_code = teachers.teachers_code left join persons on teachers.person_id = persons.person_id left join course_offerings on eval_status.course_code = course_offerings.course_code where eval_status.stu_num = stu;
    End
DELIMITER ;

-- evaluate a teacher
DELIMITER //
Create Procedure evaluate_teacher(IN stu int, IN t_num int, IN c_code int, in f_code varchar(128), in q1 int, in q2 int, in q3 int, in q4 int, in q5 int, in q6 int, in q7 int, in q8 int, in q9 int, in q10 int)
	Begin
		Insert into eval_status (stu_num, teachers_code, course_code, eval_date, form_code) values (stu, t_num, c_code, curdate(), f_code);
        Insert into forms(form_code, teachers_code, q1_score, q2_score, q3_score, q4_score, q5_score, q6_score, q7_score, q8_score, q9_score, q10_score) values (f_code, t_num, q1,q2,q3,q4,q5,q6,q7,q8,q9,q10);
    End
DELIMITER ;

-- open a student's info
DELIMITER //
Create Procedure open_student_info(IN stu int)
		BEGIN
			SELECT persons.PERSON_ID,STU_NUM,FNAME,MNAME,LNAME,DOB, YR_START FROM EVALUATION.PERSONS JOIN EVALUATION.STUDENTS USING(person_id) where stu_num is not null and stu_num = stu and status_code = 1;
        END
DELIMITER ;

-- view a teacher's eval scores per course
DELIMITER //
Create Procedure check_eval_scores(IN t_code int, IN c_code int)
	BEGIN
		select eval_status.teachers_code,eval_status.course_code, avg(q1_score), avg(q2_score), avg(q3_score), avg(q4_score), avg(q5_score), avg(q6_score), avg(q7_score), avg(q8_score), avg(q9_score), avg(q10_score) from eval_status join forms USING(form_code) where eval_status.teachers_code = t_code and eval_status.course_code = c_code;
    END
DELIMITER ;



