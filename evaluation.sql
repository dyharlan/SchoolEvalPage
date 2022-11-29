CREATE DATABASE evaluation;
USE evaluation;

CREATE TABLE personss(
person_id INT NOT NULL AUTO_INCREMENT,
FNAME VARCHAR(35) NOT NULL,
MNAME VARCHAR(25),
LNAME VARCHAR(30) NOT NULL,
DOB DATE NOT NULL,
YR_START INT NOT NULL,
PRIMARY KEY (person_id)
);	

CREATE TABLE students(
person_id INT NOT NULL,
STU_NUM INT NOT NULL UNIQUE,
FOREIGN KEY (person_id) REFERENCES personss(person_id),
PRIMARY KEY (STU_NUM, person_id)
);

CREATE TABLE departments(
DEPT_ID INT NOT NULL,
DEPT_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY (DEPT_ID)
);

CREATE TABLE teacherss(
person_id INT NOT NULL,
teachers_CODE INT NOT NULL UNIQUE,
DEPT_ID INT NOT NULL,
FOREIGN KEY (person_id) REFERENCES personss(person_id),
FOREIGN KEY (DEPT_ID) REFERENCES departments(DEPT_ID),
PRIMARY KEY (teachers_CODE, person_id)
);



CREATE TABLE course_offerings(
COURSE_CODE INT NOT NULL,
COURSE_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(COURSE_CODE)
);

CREATE TABLE course_assignments(
COURSE_CODE INT NOT NULL,
teachers_CODE INT NOT NULL,
CLASS_CODE INT NOT NULL,
FOREIGN KEY (teachers_CODE) REFERENCES teacherss(teachers_CODE),
FOREIGN KEY (COURSE_CODE) REFERENCES course_offerings(COURSE_CODE),
UNIQUE(COURSE_CODE, CLASS_CODE)
);

CREATE TABLE classes(
CLASS_CODE INT NOT NULL,
CLASS_NAME VARCHAR(50) NOT NULL,
teachers_CODE INT NOT NULL,
FOREIGN KEY (teachers_CODE) REFERENCES teacherss(teachers_CODE),
PRIMARY KEY (CLASS_CODE)
);

CREATE TABLE class_student_lists(
STU_NUM INT NOT NULL UNIQUE KEY,
CLASS_CODE INT NOT NULL,
FOREIGN KEY (CLASS_CODE) REFERENCES classes(CLASS_CODE),
FOREIGN KEY (STU_NUM) REFERENCES students(STU_NUM)
);

CREATE TABLE eval_status(
    STU_NUM INT NOT NULL KEY,
    teachers_CODE INT NOT NULL ,
    COURSE_CODE INT NOT NULL ,
    EVAL_DATE DATE NOT NULL,
    FORM_CODE INT NOT NULL UNIQUE,
    FOREIGN KEY (STU_NUM) REFERENCES students(STU_NUM),
    FOREIGN KEY (teachers_CODE) REFERENCES teacherss(teachers_CODE),
	FOREIGN KEY (COURSE_CODE) REFERENCES course_offerings(COURSE_CODE),
    UNIQUE(STU_NUM, COURSE_CODE)
);

CREATE TABLE forms(
    FORM_CODE INT NOT NULL,
<<<<<<< Updated upstream
    TEACHER_CODE INT NOT NULL,
=======
    teacher_num INT NOT NULL,
>>>>>>> Stashed changes
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
    FOREIGN KEY (FORM_CODE) REFERENCES eval_status(FORM_CODE),
    FOREIGN KEY (TEACHER_CODE) REFERENCES teachers(TEACHER_CODE),
    UNIQUE(FORM_CODE, TEACHER_CODE)
);

use evaluation;

use evaluation;
SELECT STU_NUM FROM evaluation.students where stu_num = 202212345;
SELECT * FROM evaluation.persons where person_id = (select person_id from evaluation.students where stu_num = 202212345);

-- list the teachers the student has in their class
SELECT course_assignments.TEACHER_CODE, COURSE_CODE, persons.FName, persons.Lname FROM course_assignments left join teachers on teachers.teacher_code = course_assignments.teacher_code left join persons on persons.person_id = teachers.person_id where class_code = (select class_code from class_student_lists where stu_num = 202242069);
-- list the teachers the student has in their class with full info
SELECT course_assignments.class_code, teachers.TEACHER_CODE As "Teacher Code", course_assignments.course_code As "Course Code", persons.FNAME As "First Name", persons.MNAME As "Middle Name", persons.LNAME As "Last Name", DOB As "Date-of-Birth" FROM EVALUATION.PERSONS LEFT JOIN EVALUATION.TEACHERS ON persons.person_id = teachers.person_id LEFT JOIN EVALUATION.course_assignments ON TEACHERS.TEACHER_CODE = course_assignments.TEACHER_CODE where TEACHERS.TEACHER_CODE is not null and TEACHERS.TEACHER_CODE in (SELECT TEACHER_CODE FROM course_assignments 
where class_code = (select class_code from class_student_lists where stu_num = 202213379)) AND course_assignments.class_code = (select class_code from class_student_lists where stu_num = 202213379) order by persons.person_id asc;


-- list the teachers from an entire college campus
SELECT persons.PERSON_ID As "Person ID",TEACHER_CODE As "Teacher Code",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth" FROM EVALUATION.PERSONS LEFT JOIN EVALUATION.TEACHERS ON persons.person_id = teachers.person_id where TEACHER_CODE is not null;

-- view the teachers that the student has evaluated
select teacher_code, course_code FROM eval_status where eval_status.stu_num = 202242069;
-- view the teachers that the student has NOT evaluated
SELECT course_assignments.teacher_code, course_assignments.course_code FROM course_assignments left join eval_status on course_assignments.teacher_code = eval_status.teacher_code and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_lists where stu_num = 202269420 ) where class_code = (select class_code from class_student_lists where stu_num = 202269420) and eval_status.teacher_code is null and eval_status.course_code is null order by course_code asc;

-- view the teachers with their name that the student has evaluated 
select persons.fname, persons.lname, eval_status.teacher_code, eval_status.course_code, course_offerings.course_name FROM eval_status left join teachers on eval_status.teacher_code = teachers.teacher_code left join persons on teachers.person_id = persons.person_id left join course_offerings on eval_status.course_code = course_offerings.course_code where eval_status.stu_num = 202242069;
-- view the teachers with their name that the student has NOT evaluated
SELECT persons.fname, persons.lname, course_assignments.teacher_code, course_assignments.course_code, course_offerings.course_name FROM course_assignments 
left join eval_status on course_assignments.teacher_code = eval_status.teacher_code and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_lists where stu_num = 202242069) 
left join teachers on course_assignments.teacher_code = teachers.teacher_code left join persons on teachers.person_id = persons.person_id
left join course_offerings on course_assignments.course_code = course_offerings.course_code
where class_code = (select class_code from class_student_lists where stu_num = 202242069) 
 and eval_status.teacher_code is null and eval_status.course_code is null order by course_code asc;

 
-- view all students
SELECT persons.PERSON_ID As "Person ID",STU_NUM As "Student Number",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth", YR_START As "Year Started" FROM EVALUATION.PERSONS LEFT JOIN EVALUATION.STUDENTS ON persons.person_id = students.person_id where stu_num is not null;
-- view a specific student
SELECT persons.PERSON_ID As "Person ID",STU_NUM As "Student Number",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth", YR_START As "Year Started" FROM EVALUATION.PERSONS LEFT JOIN EVALUATION.STUDENTS ON persons.person_id = students.person_id where stu_num is not null and stu_num = 202269420;


-- CREATE VIEW VIEW_TEACHERS AS SELECT TEACHER_CODE FROM teacher_assignment where class_code = (select class_code from class_student_lists) ORDER BY TEACHER_CODE;
-- select * from view_TEACHERS  where class_student_lists.stu_num = 202269420;

