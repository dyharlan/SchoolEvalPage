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
Create Procedure evaluate_teacher(IN stu int, IN t_num int, IN c_code int, in f_code int)
	Begin
		Insert into eval_status (stu_num, teachers_code, course_code, eval_date, form_code) values (stu, t_num, c_code, curdate(), f_code);
    End
DELIMITER ;
SELECT * FROM evaluation.forms;
