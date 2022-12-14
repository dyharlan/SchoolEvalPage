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
        <title>Form Page</title>
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
            if (session.getAttribute("STU_NUM") == null) //if one tries to access this page illegally, redirects to login page
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
                    <div><input type="radio" name="q1" id="q1-5" value="5" required><label for="q1-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q1" id="q1-4" value="4" required><label for="q1-4">Satisfactory</label></div>
                    <div><input type="radio" name="q1" id="q1-3" value="3" required><label for="q1-3">Average</label></div>
                    <div><input type="radio" name="q1" id="q1-2" value="2" required><label for="q1-2">Poor</label></div>
                    <div><input type="radio" name="q1" id="q1-1" value="1" required><label for="q1-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>2. The teacher incorporates various sources and modes for students to make use of.</legend>
                    <div><input type="radio" name="q2" id="q2-5" value="5" required><label for="q2-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q2" id="q2-4" value="4" required><label for="q2-4">Satisfactory</label></div>
                    <div><input type="radio" name="q2" id="q2-3" value="3" required><label for="q2-3">Average</label></div>
                    <div><input type="radio" name="q2" id="q2-2" value="2" required><label for="q2-2">Poor</label></div>
                    <div><input type="radio" name="q2" id="q2-1" value="1" required><label for="q2-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>3. The teacher follows and is a great example of following the University's Code of Ethics.</legend>
                    <div><input type="radio" name="q3" id="q3-5" value="5" required><label for="q3-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q3" id="q3-4" value="4" required><label for="q3-4">Satisfactory</label></div>
                    <div><input type="radio" name="q3" id="q3-3" value="3" required><label for="q3-3">Average</label></div>
                    <div><input type="radio" name="q3" id="q3-2" value="2" required><label for="q3-2">Poor</label></div>
                    <div><input type="radio" name="q3" id="q3-1" value="1" required><label for="q3-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>4. The teacher has been receptive, adaptive, and addresses feedback received from their students.</legend>
                    <div><input type="radio" name="q4" id="q4-5" value="5" required><label for="q4-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q4" id="q4-4" value="4" required><label for="q4-4">Satisfactory</label></div>
                    <div><input type="radio" name="q4" id="q4-3" value="3" required><label for="q4-3">Average</label></div>
                    <div><input type="radio" name="q4" id="q4-2" value="2" required><label for="q4-2">Poor</label></div>
                    <div><input type="radio" name="q4" id="q4-1" value="1" required><label for="q4-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>5. The teacher gives a fair and justifiable evaluation to their students.</legend>
                    <div><input type="radio" name="q5" id="q5-5" value="5" required><label for="q5-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q5" id="q5-4" value="4" required><label for="q5-4">Satisfactory</label></div>
                    <div><input type="radio" name="q5" id="q5-3" value="3" required><label for="q5-3">Average</label></div>
                    <div><input type="radio" name="q5" id="q5-2" value="2" required><label for="q5-2">Poor</label></div>
                    <div><input type="radio" name="q5" id="q5-1" value="1" required><label for="q5-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>6. The teacher's activities have a reasonable load and timeframe allotted to them.</legend>
                    <div><input type="radio" name="q6" id="q6-5" value="5" required><label for="q6-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q6" id="q6-4" value="4" required><label for="q6-4">Satisfactory</label></div>
                    <div><input type="radio" name="q6" id="q6-3" value="3" required><label for="q6-3">Average</label></div>
                    <div><input type="radio" name="q6" id="q6-2" value="2" required><label for="q6-2">Poor</label></div>
                    <div><input type="radio" name="q6" id="q6-1" value="1" required><label for="q6-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>7. The teacher's personality and charisma best reflects the University.</legend>
                    <div><input type="radio" name="q7" id="q7-5" value="5" required><label for="q7-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q7" id="q7-4" value="4" required><label for="q7-4">Satisfactory</label></div>
                    <div><input type="radio" name="q7" id="q7-3" value="3" required><label for="q7-3">Average</label></div>
                    <div><input type="radio" name="q7" id="q7-2" value="2" required><label for="q7-2">Poor</label></div>
                    <div><input type="radio" name="q7" id="q7-1" value="1" required><label for="q7-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>8. The teacher provides ample and timely feedback for students to reflect and improve on.</legend>
                    <div><input type="radio" name="q8" id="q8-5" value="5" required><label for="q8-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q8" id="q8-4" value="4" required><label for="q8-4">Satisfactory</label></div>
                    <div><input type="radio" name="q8" id="q8-3" value="3" required><label for="q8-3">Average</label></div>
                    <div><input type="radio" name="q8" id="q8-2" value="2" required><label for="q8-2">Poor</label></div>
                    <div><input type="radio" name="q8" id="q8-1" value="1" required><label for="q8-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>9. The teacher shows results of assessments on time and explains clearly how they are evaluated.</legend>
                    <div><input type="radio" name="q9" id="q9-5" value="5" required><label for="q9-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q9" id="q9-4" value="4" required><label for="q9-4">Satisfactory</label></div>
                    <div><input type="radio" name="q9" id="q9-3" value="3" required><label for="q9-3">Average</label></div>
                    <div><input type="radio" name="q9" id="q9-2" value="2" required><label for="q9-2">Poor</label></div>
                    <div><input type="radio" name="q9" id="q9-1" value="1" required><label for="q9-1">Needs Improvement</label></div>
                </fieldset>

                <fieldset>
                    <legend>10. The teacher is effective in instruction to their students.</legend>
                    <div><input type="radio" name="q10" id="q10-5" value="5" required><label for="q10-5">Above Satisfactory</label></div>
                    <div><input type="radio" name="q10" id="q10-4" value="4" required><label for="q10-4">Satisfactory</label></div>
                    <div><input type="radio" name="q10" id="q10-3" value="3" required><label for="q10-3">Average</label></div>
                    <div><input type="radio" name="q10" id="q10-2" value="2" required><label for="q10-2">Poor</label></div>
                    <div><input type="radio" name="q10" id="q10-1" value="1" required><label for="q10-1">Needs Improvement</label></div>
                </fieldset>

                <input type="submit" value="Submit Form">
            </form>
        </main>
        <footer>
            <div class="strip">
                <p>
                    Copyright 2022, Cassandro Systems, Ltd.
                    <br>
                    This page only serves a purpose meant for systems evaluation and is not representative of the final product.
                </p>
            </div>
        </footer>
    </body>
</html>
