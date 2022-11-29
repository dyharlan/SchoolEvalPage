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
    </head>
    <body>
        <%
            
            response.setHeader("Cache-Control", "no-cache, no-store, must-revalidate"); //http 1.1+
            response.setHeader("Pragma", "no-cache"); //http 1.0
            response.setHeader("Expires", "0"); //for proxy
            if(session.getAttribute("STU_NUM") == null)
                response.sendRedirect("login.jsp");
        %>
        <h1><%= session.getAttribute("STU_NUM")%>, <%= request.getParameter("teacher_num")%>, <%= request.getParameter("course_code")%></h1>
        
        <form action="EvalProcessor" method="POST">
            <input type="hidden" id="teacher_num" name="teacher_num" value="<%= request.getParameter("teacher_num")%>">
            <input type="hidden" id="course_code" name="course_code" value="<%= request.getParameter("course_code")%>">

            <fieldset>
                <legend>1. The teacher has been present and punctual at attending classes</legend>
                <input type="radio" name="q1" id="q1" value="5" required><label for="q1">5</label>
                <input type="radio" name="q1" id="q1" value="4" required><label for="q1">4</label>
                <input type="radio" name="q1" id="q1" value="3" required><label for="q1">3</label>
                <input type="radio" name="q1" id="q1" value="2" required><label for="q1">2</label>
                <input type="radio" name="q1" id="q1" value="1" required><label for="q1">1</label>
            </fieldset>
            
            <fieldset>
                <legend>2. The teacher incorporates various sources and modes for students to make use of</legend>
                <input type="radio" name="q2" id="q2" value="5" required><label for="q2">5</label>
                <input type="radio" name="q2" id="q2" value="4" required><label for="q2">4</label>
                <input type="radio" name="q2" id="q2" value="3" required><label for="q2">3</label>
                <input type="radio" name="q2" id="q2" value="2" required><label for="q2">2</label>
                <input type="radio" name="q2" id="q2" value="1" required><label for="q2">1</label>
            </fieldset>
            
            <fieldset>
                <legend>3. The teacher follows and is a great example of following the University's Code of Ethics</legend>
                <input type="radio" name="q3" id="q3" value="5" required><label for="q3">5</label>
                <input type="radio" name="q3" id="q3" value="4" required><label for="q3">4</label>
                <input type="radio" name="q3" id="q3" value="3" required><label for="q3">3</label>
                <input type="radio" name="q3" id="q3" value="2" required><label for="q3">2</label>
                <input type="radio" name="q3" id="q3" value="1" required><label for="q3">1</label>
            </fieldset>
            
            <fieldset>
                <legend>4. The teacher has been receptive, adaptive, and addresses feedback received from their students</legend>
                <input type="radio" name="q4" id="q4" value="5" required><label for="q4">5</label>
                <input type="radio" name="q4" id="q4" value="4" required><label for="q4">4</label>
                <input type="radio" name="q4" id="q4" value="3" required><label for="q4">3</label>
                <input type="radio" name="q4" id="q4" value="2" required><label for="q4">2</label>
                <input type="radio" name="q4" id="q4" value="1" required><label for="q4">1</label>
            </fieldset>
            
            <fieldset>
                <legend>5. The teacher gives a fair and justifiable evaluation to their students</legend>
                <input type="radio" name="q5" id="q5" value="5" required><label for="q5">5</label>
                <input type="radio" name="q5" id="q5" value="4" required><label for="q5">4</label>
                <input type="radio" name="q5" id="q5" value="3" required><label for="q5">3</label>
                <input type="radio" name="q5" id="q5" value="2" required><label for="q5">2</label>
                <input type="radio" name="q5" id="q5" value="1" required><label for="q5">1</label>
            </fieldset>
            
             <fieldset>
                <legend>6. The teacher's activities have a reasonable load and timeframe allotted to them</legend>
                <input type="radio" name="q6" id="q6" value="5" required><label for="q6">5</label>
                <input type="radio" name="q6" id="q6" value="4" required><label for="q6">4</label>
                <input type="radio" name="q6" id="q6" value="3" required><label for="q6">3</label>
                <input type="radio" name="q6" id="q6" value="2" required><label for="q6">2</label>
                <input type="radio" name="q6" id="q6" value="1" required><label for="q6">1</label>
            </fieldset>

            <fieldset>
                <legend>7. The teacher's personality and charisma best reflects the University</legend>
                <input type="radio" name="q7" id="q7" value="5" required><label for="q7">5</label>
                <input type="radio" name="q7" id="q7" value="4" required><label for="q7">4</label>
                <input type="radio" name="q7" id="q7" value="3" required><label for="q7">3</label>
                <input type="radio" name="q7" id="q7" value="2" required><label for="q7">2</label>
                <input type="radio" name="q7" id="q7" value="1" required><label for="q7">1</label>
            </fieldset>

            <fieldset>
                <legend>8. The teacher provides ample and timely feedback for students to reflect and improve on</legend>
                <input type="radio" name="q8" id="q8" value="5" required><label for="q8">5</label>
                <input type="radio" name="q8" id="q8" value="4" required><label for="q8">4</label>
                <input type="radio" name="q8" id="q8" value="3" required><label for="q8">3</label>
                <input type="radio" name="q8" id="q8" value="2" required><label for="q8">2</label>
                <input type="radio" name="q8" id="q8" value="1" required><label for="q8">1</label>
            </fieldset>

            <fieldset>
                <legend>9. The teacher shows results of assessments on time and explains clearly how they are evaluated</legend>
                <input type="radio" name="q9" id="q9" value="5" required><label for="q9">5</label>
                <input type="radio" name="q9" id="q9" value="4" required><label for="q9">4</label>
                <input type="radio" name="q9" id="q9" value="3" required><label for="q9">3</label>
                <input type="radio" name="q9" id="q9" value="2" required><label for="q9">2</label>
                <input type="radio" name="q9" id="q9" value="1" required><label for="q9">1</label>
            </fieldset>

            <fieldset>
                <legend>10. The teacher is effective in instruction to their students</legend>
                <input type="radio" name="q10" id="q10" value="5" required><label for="q10">5</label>
                <input type="radio" name="q10" id="q10" value="4" required><label for="q10">4</label>
                <input type="radio" name="q10" id="q10" value="3" required><label for="q10">3</label>
                <input type="radio" name="q10" id="q10" value="2" required><label for="q10">2</label>
                <input type="radio" name="q10" id="q10" value="1" required><label for="q10">1</label>
            </fieldset>

            <input type="submit" value="Submit Form">
        </form>
    </body>
</html>
