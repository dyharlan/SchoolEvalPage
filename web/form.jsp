<%-- 
    Document   : form
    Created on : 28 Nov 2022, 9:43:48 pm
    Author     : dyhar
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="form.css">
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet">
    </head>
    <body>
        <%

            response.setHeader("Cache-Control", "no-cache, no-store, must-revalidate"); //http 1.1+
            response.setHeader("Pragma", "no-cache"); //http 1.0
            response.setHeader("Expires", "0"); //for proxy
            if (session.getAttribute("STU_NUM") == null)
                response.sendRedirect("login.jsp");
        %>
        <main>
            <h1>Form for <%= request.getParameter("LName")%>, <%= request.getParameter("FName")%> - <%= request.getParameter("course_code")%></h1>
        <!--<h1><%--<%= session.getAttribute("STU_NUM")%>, <%= request.getParameter("teacher_num")%>, <%= request.getParameter("course_code")%>--%></h1>-->

            <form action="EvalProcessor" method="POST">
                <input type="hidden" id="teacher_num" name="teacher_num" value="<%= request.getParameter("teacher_num")%>">
                <input type="hidden" id="course_code" name="course_code" value="<%= request.getParameter("course_code")%>">

                <fieldset>
                    <legend>1. The teacher has been present and punctual at attending classes.</legend>
                    <div><input type="radio" name="q1" id="q1" value="5" required><label for="q1">Above Satisfactory</label></div>
                    <div><input type="radio" name="q1" id="q1" value="4" required><label for="q1">Satisfactory</label></div>
                    <div><input type="radio" name="q1" id="q1" value="3" required><label for="q1">Average</label></div>
                    <div><input type="radio" name="q1" id="q1" value="2" required><label for="q1">Poor</label></div>
                    <div><input type="radio" name="q1" id="q1" value="1" required><label for="q1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>2. The teacher incorporates various sources and modes for students to make use of.</legend>
                    <div><input type="radio" name="q2" id="q2" value="5" required><label for="q2">Above Satisfactory</label></div>
                    <div><input type="radio" name="q2" id="q2" value="4" required><label for="q2">Satisfactory</label></div>
                    <div><input type="radio" name="q2" id="q2" value="3" required><label for="q2">Average</label></div>
                    <div><input type="radio" name="q2" id="q2" value="2" required><label for="q2">Poor</label></div>
                    <div><input type="radio" name="q2" id="q2" value="1" required><label for="q2">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>3. The teacher follows and is a great example of following the University's Code of Ethics.</legend>
                    <div><input type="radio" name="q3" id="q3" value="5" required><label for="q3">Above Satisfactory</label></div>
                    <div><input type="radio" name="q3" id="q3" value="4" required><label for="q3">Satisfactory</label></div>
                    <div><input type="radio" name="q3" id="q3" value="3" required><label for="q3">Average</label></div>
                    <div><input type="radio" name="q3" id="q3" value="2" required><label for="q3">Poor</label></div>
                    <div><input type="radio" name="q3" id="q3" value="1" required><label for="q3">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>4. The teacher has been receptive, adaptive, and addresses feedback received from their students.</legend>
                    <div><input type="radio" name="q4" id="q4" value="5" required><label for="q4">Above Satisfactory</label></div>
                    <div><input type="radio" name="q4" id="q4" value="4" required><label for="q4">Satisfactory</label></div>
                    <div><input type="radio" name="q4" id="q4" value="3" required><label for="q4">Average</label></div>
                    <div><input type="radio" name="q4" id="q4" value="2" required><label for="q4">Poor</label></div>
                    <div><input type="radio" name="q4" id="q4" value="1" required><label for="q4">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>5. The teacher gives a fair and justifiable evaluation to their students.</legend>
                    <div><input type="radio" name="q5" id="q5" value="5" required><label for="q5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q5" id="q5" value="4" required><label for="q5">Satisfactory</label></div>
                    <div><input type="radio" name="q5" id="q5" value="3" required><label for="q5">Average</label></div>
                    <div><input type="radio" name="q5" id="q5" value="2" required><label for="q5">Poor</label></div>
                    <div><input type="radio" name="q5" id="q5" value="1" required><label for="q5">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>6. The teacher's activities have a reasonable load and timeframe allotted to them.</legend>
                    <div><input type="radio" name="q6" id="q6" value="5" required><label for="q6">Above Satisfactory</label></div>
                    <div><input type="radio" name="q6" id="q6" value="4" required><label for="q6">Satisfactory</label></div>
                    <div><input type="radio" name="q6" id="q6" value="3" required><label for="q6">Average</label></div>
                    <div><input type="radio" name="q6" id="q6" value="2" required><label for="q6">Poor</label></div>
                    <div><input type="radio" name="q6" id="q6" value="1" required><label for="q6">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>7. The teacher's personality and charisma best reflects the University.</legend>
                    <div><input type="radio" name="q7" id="q7" value="5" required><label for="q7">Above Satisfactory</label></div>
                    <div><input type="radio" name="q7" id="q7" value="4" required><label for="q7">Satisfactory</label></div>
                    <div><input type="radio" name="q7" id="q7" value="3" required><label for="q7">Average</label></div>
                    <div><input type="radio" name="q7" id="q7" value="2" required><label for="q7">Poor</label></div>
                    <div><input type="radio" name="q7" id="q7" value="1" required><label for="q7">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>8. The teacher provides ample and timely feedback for students to reflect and improve on.</legend>
                    <div><input type="radio" name="q8" id="q8" value="5" required><label for="q8">Above Satisfactory</label></div>
                    <div><input type="radio" name="q8" id="q8" value="4" required><label for="q8">Satisfactory</label></div>
                    <div><input type="radio" name="q8" id="q8" value="3" required><label for="q8">Average</label></div>
                    <div><input type="radio" name="q8" id="q8" value="2" required><label for="q8">Poor</label></div>
                    <div><input type="radio" name="q8" id="q8" value="1" required><label for="q8">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>9. The teacher shows results of assessments on time and explains clearly how they are evaluated.</legend>
                    <div><input type="radio" name="q9" id="q9" value="5" required><label for="q9">Above Satisfactory</label></div>
                    <div><input type="radio" name="q9" id="q9" value="4" required><label for="q9">Satisfactory</label></div>
                    <div><input type="radio" name="q9" id="q9" value="3" required><label for="q9">Average</label></div>
                    <div><input type="radio" name="q9" id="q9" value="2" required><label for="q9">Poor</label></div>
                    <div><input type="radio" name="q9" id="q9" value="1" required><label for="q9">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>10. The teacher is effective in instruction to their students.</legend>
                    <div><input type="radio" name="q10" id="q10" value="5" required><label for="q10">Above Satisfactory</label></div>
                    <div><input type="radio" name="q10" id="q10" value="4" required><label for="q10">Satisfactory</label></div>
                    <div><input type="radio" name="q10" id="q10" value="3" required><label for="q10">Average</label></div>
                    <div><input type="radio" name="q10" id="q10" value="2" required><label for="q10">Poor</label></div>
                    <div><input type="radio" name="q10" id="q10" value="1" required><label for="q10">Needs Improvement</label></div>
                </fieldset>

                <input type="submit" value="Submit Form">
            </form>
        </main>
        <footer>
            <div class="strip">
                <p>
                    Copyright 2022, Cassandro Systems, Ltd.
                    <br>
                    This page only serves a purpose for systems evaluation and is not representative of the final product.
                </p>
            </div>
        </footer>
    </body>
</html>
