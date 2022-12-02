CREATE DATABASE evaluation;
USE evaluation;

CREATE TABLE persons(
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
FOREIGN KEY (person_id) REFERENCES persons(person_id) ON DELETE CASCADE,
PRIMARY KEY (STU_NUM, person_id)
);

CREATE TABLE departments(
DEPT_ID INT NOT NULL,
DEPT_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY (DEPT_ID)
);

CREATE TABLE teachers(
person_id INT NOT NULL,
teachers_CODE INT NOT NULL UNIQUE,
FOREIGN KEY (person_id) REFERENCES persons(person_id) ON DELETE CASCADE,
PRIMARY KEY (teachers_CODE, person_id)
);

CREATE TABLE person_role(
ROLE_CODE INT NOT NULL,
ROLE_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY (ROLE_CODE)
);

CREATE TABLE course_offerings(
COURSE_CODE INT NOT NULL,
COURSE_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(COURSE_CODE)
);

CREATE TABLE classes(
CLASS_CODE INT NOT NULL,
CLASS_NAME VARCHAR(50) NOT NULL,
PRIMARY KEY (CLASS_CODE)
);


CREATE TABLE course_assignments(
COURSE_CODE INT NOT NULL,
teachers_CODE INT NOT NULL,
CLASS_CODE INT NOT NULL,
FOREIGN KEY (teachers_CODE) REFERENCES teachers(teachers_CODE) ON DELETE CASCADE,
FOREIGN KEY (COURSE_CODE) REFERENCES course_offerings(COURSE_CODE) ON DELETE CASCADE,
FOREIGN KEY (CLASS_CODE) REFERENCES CLASSES(CLASS_CODE) ON DELETE CASCADE,
UNIQUE(COURSE_CODE, CLASS_CODE),
PRIMARY KEY(COURSE_CODE, TEACHERS_CODE, CLASS_CODE)
);

CREATE TABLE class_advisors(
	CLASS_CODE INT NOT NULL KEY,
	teachers_CODE INT NOT NULL,
	FOREIGN KEY (CLASS_CODE) REFERENCES CLASSES(CLASS_CODE) ON DELETE CASCADE,
	FOREIGN KEY (teachers_CODE) REFERENCES teachers(teachers_CODE) ON DELETE CASCADE
);

CREATE TABLE class_student_lists(
STU_NUM INT NOT NULL UNIQUE KEY,
CLASS_CODE INT NOT NULL,
FOREIGN KEY (CLASS_CODE) REFERENCES classes(CLASS_CODE) ON DELETE CASCADE,
FOREIGN KEY (STU_NUM) REFERENCES students(STU_NUM) ON DELETE CASCADE
);

CREATE TABLE eval_status(
	FORM_CODE VARCHAR(128) NOT NULL KEY,
    STU_NUM INT NOT NULL,
    teachers_CODE INT NOT NULL,
    COURSE_CODE INT NOT NULL,
    EVAL_DATE DATE NOT NULL,
    FOREIGN KEY (STU_NUM) REFERENCES students(STU_NUM) ON DELETE CASCADE,
    FOREIGN KEY (teachers_CODE) REFERENCES teachers(teachers_CODE) ON DELETE CASCADE,
	FOREIGN KEY (COURSE_CODE) REFERENCES course_offerings(COURSE_CODE) ON DELETE CASCADE,
    UNIQUE(STU_NUM, COURSE_CODE)
);

CREATE TABLE forms(
    FORM_CODE VARCHAR(128) NOT NULL,
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

use evaluation;
SELECT STU_NUM FROM evaluation.students where stu_num = 202212345;
SELECT * FROM evaluation.persons where person_id = (select person_id from evaluation.students where stu_num = 202212345);

-- list the teachers the student has in their class
select class_code, teachers_code As "Teacher's Code", course_code As "Course Code", CONCAT(FNAME, " " ,LNAME) As "Name" from course_assignments join teachers using(teachers_code) join persons using(person_id) where class_code = (select class_code from class_student_lists where stu_num = 202242069);
-- list the teachers the student has in their class with full info
select class_code, teachers_code As "Teacher's Code", course_code As "Course Code", CONCAT(FNAME, " " ,LNAME) As "Name", DOB As "Date-of-Birth" from course_assignments join teachers using(teachers_code) join persons using(person_id) where class_code = (select class_code from class_student_lists where stu_num = 202242069);
-- list the teachers from an entire college campus
SELECT persons.PERSON_ID As "Person ID", TEACHERS_CODE As "Teacher Code",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth" FROM TEACHERS JOIN PERSONS USING(PERSON_ID);
-- view the teachers that the student has evaluated
select teachers_code, course_code FROM eval_status where eval_status.stu_num = 202242069;
-- view the teachers that the student has NOT evaluated
SELECT course_assignments.teachers_code, course_assignments.course_code FROM course_assignments left join eval_status on course_assignments.teachers_code = eval_status.teachers_code and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_lists where stu_num = 202269420 ) where class_code = (select class_code from class_student_lists where stu_num = 202269420) and eval_status.teachers_code is null and eval_status.course_code is null order by course_code asc;
-- view the teachers with their name that the student has evaluated 
select persons.fname, persons.lname, eval_status.teachers_code, eval_status.course_code, course_offerings.course_name FROM eval_status left join teachers on eval_status.teachers_code = teachers.teachers_code left join persons on teachers.person_id = persons.person_id left join course_offerings on eval_status.course_code = course_offerings.course_code where eval_status.stu_num = 202242069;
-- view the teachers with their name that the student has NOT evaluated
SELECT persons.fname, persons.lname, course_assignments.teachers_code, course_assignments.course_code, course_offerings.course_name FROM course_assignments 
left join eval_status on course_assignments.teachers_code = eval_status.teachers_code and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_lists where stu_num = 202242069) 
left join teachers on course_assignments.teachers_code = teachers.teachers_code left join persons on teachers.person_id = persons.person_id
left join course_offerings on course_assignments.course_code = course_offerings.course_code
where class_code = (select class_code from class_student_lists where stu_num = 202242069) 
 and eval_status.teachers_code is null and eval_status.course_code is null order by course_code asc;
 
-- view the avg scores that a teacher has received for a course they teach.
SELECT eval_status.teachers_code,eval_status.course_code, q1_score,q2_score, q3_score,q4_score, q5_score, q6_score, q7_score, q8_score, q9_score, q10_score from eval_status join forms USING(form_code) where eval_status.teachers_code = 2022750511 and eval_status.course_code = 2605;
select eval_status.teachers_code,eval_status.course_code, avg(q1_score), avg(q2_score), avg(q3_score), avg(q4_score), avg(q5_score), avg(q6_score), avg(q7_score), avg(q8_score), avg(q9_score), avg(q10_score) from eval_status join forms USING(form_code) where eval_status.teachers_code = 2022750511 and eval_status.course_code = 2605;

-- view the avg scores that a teacher has received for a course they teach. Rounded down to two places
select teachers_code, course_code, round(avg(q1_score), 2), round(avg(q2_score), 2), round(avg(q3_score), 2), round(avg(q4_score), 2), round(avg(q5_score), 2), round(avg(q6_score), 2), round(avg(q7_score), 2), round(avg(q8_score), 2), round(avg(q9_score), 2), round(avg(q10_score), 2) from forms where teachers_code = 2022750511 and course_code = 2605;

-- view all students
SELECT persons.PERSON_ID As "Person ID",STU_NUM As "Student Number",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth", YR_START As "Year Started" FROM EVALUATION.PERSONS JOIN EVALUATION.STUDENTS ON persons.person_id = students.person_id where stu_num is not null;
-- view a specific student
SELECT persons.PERSON_ID As "Person ID",STU_NUM As "Student Number",FNAME As "First Name",MNAME As "Middle Name",LNAME As "Last Name",DOB As "Date-of-Birth", YR_START As "Year Started" FROM EVALUATION.PERSONS JOIN EVALUATION.STUDENTS ON persons.person_id = students.person_id where stu_num is not null and stu_num = 202269420;


-- CREATE VIEW VIEW_TEACHERS AS SELECT TEACHER_CODE FROM teacher_assignment where class_code = (select class_code from class_student_lists) ORDER BY TEACHER_CODE;
-- select * from view_TEACHERS  where class_student_lists.stu_num = 202269420;

