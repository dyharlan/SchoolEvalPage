CREATE DATABASE evaluation;

USE evaluation ;

CREATE TABLE person_roles
(ROLE_CODE INT NOT NULL,
ROLE_NAME VARCHAR(30) NOT NULL,
PRIMARY KEY(ROLE_CODE));

CREATE TABLE PERSON_STATUS(
    STATUS_CODE INT NOT NULL,
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
PERSON_STATUS INT NOT NULL,
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
FORM_CODE INT Not NULL UNIQUE,
FOREIGN KEY(STU_NUM) REFERENCES students(STU_NUM),
FOREIGN KEY(TEACHERS_CODE) REFERENCES teachers(TEACHERS_CODE),
PRIMARY KEY(STU_NUM));


