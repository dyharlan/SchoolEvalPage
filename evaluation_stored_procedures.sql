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
CALL view_evaluated_teachers('202269420');

CALL view_unevaluated_teachers('202269420');
DELIMITER //
Create Procedure evaluate_teacher(IN stu int, IN t_num int, IN c_code int, in f_code varchar(128), in q1 int, in q2 int, in q3 int, in q4 int, in q5 int, in q6 int, in q7 int, in q8 int, in q9 int, in q10 int)
	Begin
		Insert into eval_status (stu_num, teachers_code, course_code, eval_date, form_code) values (stu, t_num, c_code, curdate(), f_code);
        Insert into forms(form_code, teachers_code, course_code, q1_score, q2_score, q3_score, q4_score, q5_score, q6_score, q7_score, q8_score, q9_score, q10_score) values (f_code, t_num, c_code, q1,q2,q3,q4,q5,q6,q7,q8,q9,q10);
        commit;
    End
DELIMITER ;
SELECT * FROM evaluation.forms;
call evaluate_teacher(202269420, 2022123496, 2602, 345677,5,5,5,5,5,5,5,5,5,5);
DELIMITER //
Create Procedure open_student_info(IN stu int)
		BEGIN
			SELECT persons.PERSON_ID,STU_NUM,FNAME,MNAME,LNAME,DOB, YR_START FROM EVALUATION.PERSONS LEFT JOIN EVALUATION.STUDENTS ON persons.person_id = students.person_id where stu_num is not null and stu_num = stu;
        END
DELIMITER ;
call open_student_info(202269420);