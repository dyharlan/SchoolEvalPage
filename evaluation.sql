CREATE DATABASE evaluation;
USE evaluation;

CREATE TABLE person(
PERSON_ID INT NOT NULL AUTO_INCREMENT,
FNAME VARCHAR(35) NOT NULL,
MNAME VARCHAR(25),
LNAME VARCHAR(30) NOT NULL,
DOB DATE NOT NULL,
YR_START INT NOT NULL,
PRIMARY KEY (PERSON_ID)
);	

CREATE TABLE student(
PERSON_ID INT NOT NULL,
STU_NUM INT NOT NULL UNIQUE,
FOREIGN KEY (PERSON_ID) REFERENCES person(PERSON_ID),
PRIMARY KEY (STU_NUM, PERSON_ID)
);

CREATE TABLE department(
DEPT_ID INT NOT NULL,
DEPT_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY (DEPT_ID)
);

CREATE TABLE teacher(
PERSON_ID INT NOT NULL,
TEACHER_NUM INT NOT NULL UNIQUE,
DEPT_ID INT NOT NULL,
FOREIGN KEY (PERSON_ID) REFERENCES person(PERSON_ID),
FOREIGN KEY (DEPT_ID) REFERENCES department(DEPT_ID),
PRIMARY KEY (TEACHER_NUM, PERSON_ID)
);



CREATE TABLE course_offerings(
COURSE_CODE INT NOT NULL,
COURSE_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(COURSE_CODE)
);

CREATE TABLE course_assignments(
COURSE_CODE INT NOT NULL,
TEACHER_NUM INT NOT NULL,
CLASS_CODE INT NOT NULL,
FOREIGN KEY (TEACHER_NUM) REFERENCES teacher(TEACHER_NUM),
FOREIGN KEY (COURSE_CODE) REFERENCES course_offerings(COURSE_CODE),
UNIQUE(COURSE_CODE, CLASS_CODE)
);

CREATE TABLE class(
CLASS_CODE INT NOT NULL,
CLASS_NAME VARCHAR(50) NOT NULL,
TEACHER_NUM INT NOT NULL,
FOREIGN KEY (TEACHER_NUM) REFERENCES teacher(TEACHER_NUM),
PRIMARY KEY (CLASS_CODE)
);

CREATE TABLE class_student_list(
STU_NUM INT NOT NULL UNIQUE KEY,
CLASS_CODE INT NOT NULL,
FOREIGN KEY (CLASS_CODE) REFERENCES class(CLASS_CODE),
FOREIGN KEY (STU_NUM) REFERENCES student(STU_NUM)
);

CREATE TABLE eval_status(
    STU_NUM INT NOT NULL KEY,
    TEACHER_NUM INT NOT NULL KEY,
    COURSE_CODE INT NOT NULL KEY,
    EVAL_DATE DATE NOT NULL,
    FORM_CODE INT NOT NULL UNIQUE,
    FOREIGN KEY (STU_NUM) REFERENCES student(STU_NUM),
    FOREIGN KEY (TEACHER_NUM) REFERENCES teacher(TEACHER_NUM),
	FOREIGN KEY (COURSE_CODE) REFERENCES course_offerings(COURSE_CODE),
    UNIQUE(STU_NUM, COURSE_CODE)
);

CREATE TABLE form(
    FORM_CODE INT NOT NULL,
    TEACHER_NUM INT NOT NULL,
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
    FOREIGN KEY (FORM_CODE) REFERENCES ecourse_assignmentsal_status(FORM_CODE),
    FOREIGN KEY (TEACHER_NUM) REFERENCES teacher(TEACHER_NUM),
    UNIQUE(FORM_CODE, TEACHER_NUM)
);

use evaluation;
SELECT STU_NUM FROM evaluation.student where stu_num = 202212345;
SELECT * FROM evaluation.person where person_id = (select person_id from evaluation.student where stu_num = 202212345);

-- list the teachers the student has in their class
SELECT course_assignments.TEACHER_NUM, COURSE_CODE, person.FName, person.Lname FROM course_assignments left join teacher on teacher.teacher_num = course_assignments.teacher_num left join person on person.person_id = teacher.person_id where class_code = (select class_code from class_student_list where stu_num = 202242069);
-- list the teachers the student has in their class with full info
SELECT course_assignments.class_code, teacher.TEACHER_NUM As "Teacher Code", course_assignments.course_code As "Course Code", person.FNAME As "First Name", person.MNAME As "Middle Name", person.LNAME As "Last Name", DOB As "Date-of-Birth" FROM EVALUATION.PERSON LEFT JOIN EVALUATION.TEACHER ON person.person_id = teacher.person_id LEFT JOIN EVALUATION.course_assignments ON TEACHER.TEACHER_NUM = course_assignments.TEACHER_NUM where TEACHER.TEACHER_NUM is not null and TEACHER.TEACHER_NUM in (SELECT TEACHER_NUM FROM course_assignments 
where class_code = (select class_code from class_student_list where stu_num = 202213379)) AND course_assignments.class_code = (select class_code from class_student_list where stu_num = 202213379) order by person.person_id asc;


-- list the teachers from an entire college campus
SELECT person.PERSON_ID As "Person ID",TEACHER_NUM As "Teacher Code",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth" FROM EVALUATION.PERSON LEFT JOIN EVALUATION.TEACHER ON person.person_id = teacher.person_id where TEACHER_NUM is not null;

-- view the teachers that the student has evaluated
select teacher_num, course_code FROM eval_status where eval_status.stu_num = 202242069;
-- view the teachers that the student has NOT evaluated
SELECT course_assignments.teacher_num, course_assignments.course_code FROM course_assignments left join eval_status on course_assignments.teacher_num = eval_status.teacher_num and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_list where stu_num = 202269420 ) where class_code = (select class_code from class_student_list where stu_num = 202269420) and eval_status.teacher_num is null and eval_status.course_code is null order by course_code asc;

-- view the teachers with their name that the student has evaluated 
select person.fname, person.lname, eval_status.teacher_num, eval_status.course_code, course_offerings.course_name FROM eval_status left join teacher on eval_status.teacher_num = teacher.teacher_num left join person on teacher.person_id = person.person_id left join course_offerings on eval_status.course_code = course_offerings.course_code where eval_status.stu_num = 202242069;
-- view the teachers with their name that the student has NOT evaluated
SELECT person.fname, person.lname, course_assignments.teacher_num, course_assignments.course_code, course_offerings.course_name FROM course_assignments 
left join eval_status on course_assignments.teacher_num = eval_status.teacher_num and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_list where stu_num = 202242069) 
left join teacher on course_assignments.teacher_num = teacher.teacher_num left join person on teacher.person_id = person.person_id
left join course_offerings on course_assignments.course_code = course_offerings.course_code
where class_code = (select class_code from class_student_list where stu_num = 202242069) 
 and eval_status.teacher_num is null and eval_status.course_code is null order by course_code asc;

 
-- view all students
SELECT person.PERSON_ID As "Person ID",STU_NUM As "Student Number",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth", YR_START As "Year Started" FROM EVALUATION.PERSON LEFT JOIN EVALUATION.STUDENT ON person.person_id = student.person_id where stu_num is not null;
-- view a specific student
SELECT person.PERSON_ID As "Person ID",STU_NUM As "Student Number",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth", YR_START As "Year Started" FROM EVALUATION.PERSON LEFT JOIN EVALUATION.STUDENT ON person.person_id = student.person_id where stu_num is not null and stu_num = 202269420;


-- CREATE VIEW VIEW_TEACHERS AS SELECT TEACHER_NUM FROM teacher_assignment where class_code = (select class_code from class_student_list) ORDER BY TEACHER_NUM;
-- select * from view_TEACHERS  where class_student_list.stu_num = 202269420;

