use evaluation;
DELIMITER //
Create Procedure view_unevaluated_teachers(IN stu int)
	Begin
		SELECT person.fname, person.lname, course_assignment.teacher_code, course_assignment.course_code, course_offering.course_name FROM course_assignment 
left join eval_status on course_assignment.teacher_code = eval_status.teacher_code and course_assignment.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_list where stu_num = stu) 
left join teacher on course_assignment.teacher_code = teacher.teacher_code left join person on teacher.person_id = person.person_id
left join course_offering on course_assignment.course_code = course_offering.course_code
where class_code = (select class_code from class_student_list where stu_num = stu) 
and eval_status.teacher_code is null and eval_status.course_code is null order by course_code asc;
    End
DELIMITER ;

DELIMITER //
Create Procedure view_evaluated_teachers(IN stu int)
	Begin
		select person.fname, person.lname, eval_status.teacher_code, eval_status.course_code, course_offering.course_name FROM eval_status left join teacher on eval_status.teacher_code = teacher.teacher_code left join person on teacher.person_id = person.person_id left join course_offering on eval_status.course_code = course_offering.course_code where eval_status.stu_num = stu;
    End
DELIMITER ;

-- evaluate a teacher
DELIMITER //
Create Procedure evaluate_teacher(IN stu int, IN t_num int, IN c_code int, in f_code varchar(128), in q1 int, in q2 int, in q3 int, in q4 int, in q5 int, in q6 int, in q7 int, in q8 int, in q9 int, in q10 int)
	Begin
		Insert into eval_status (stu_num, teacher_code, course_code, eval_date, form_code) values (stu, t_num, c_code, curdate(), f_code);
        Insert into forms(form_code, teacher_code, q1_score, q2_score, q3_score, q4_score, q5_score, q6_score, q7_score, q8_score, q9_score, q10_score) values (f_code, t_num, q1,q2,q3,q4,q5,q6,q7,q8,q9,q10);
    End
DELIMITER ;

-- open a student's info
DELIMITER //
Create Procedure open_student_info(IN stu int)
		BEGIN
			SELECT person.PERSON_ID,STU_NUM,FNAME,MNAME,LNAME,DOB, YR_START FROM EVALUATION.PERSON JOIN EVALUATION.STUDENT USING(person_id) where stu_num is not null and stu_num = stu and status_code = 1;
        END
DELIMITER ;

-- view a teacher's eval scores per course
DELIMITER //
Create Procedure check_eval_scores(IN t_code int, IN c_code int)
	BEGIN
		select eval_status.teacher_code,eval_status.course_code, avg(q1_score), avg(q2_score), avg(q3_score), avg(q4_score), avg(q5_score), avg(q6_score), avg(q7_score), avg(q8_score), avg(q9_score), avg(q10_score) from eval_status join forms USING(form_code) where eval_status.teacher_code = t_code and eval_status.course_code = c_code;
    END
DELIMITER ;
