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
            <fieldset>
                <legend>1. The teacher has been present and punctual at attending classes</legend>
                <input type="radio" name="q1" id="q1" value="5"><label for="q1">5</label>
                <input type="radio" name="q1" id="q1" value="4"><label for="q1">4</label>
                <input type="radio" name="q1" id="q1" value="3"><label for="q1">3</label>
                <input type="radio" name="q1" id="q1" value="2"><label for="q1">2</label>
                <input type="radio" name="q1" id="q1" value="1"><label for="q1">1</label>
            </fieldset>
            
            <fieldset>
                <legend>2. The teacher incorporates various sources and modes for students to make use of</legend>
                <input type="radio" name="q2" id="q2" value="5"><label for="q2">5</label>
                <input type="radio" name="q2" id="q2" value="4"><label for="q2">4</label>
                <input type="radio" name="q2" id="q2" value="3"><label for="q2">3</label>
                <input type="radio" name="q2" id="q2" value="2"><label for="q2">2</label>
                <input type="radio" name="q2" id="q2" value="1"><label for="q2">1</label>
            </fieldset>
            
            <fieldset>
                <legend>3. The teacher follows and is a great example of following the University's Code of Ethics</legend>
                <input type="radio" name="q3" value="5"><label for="q3">5</label>
                <input type="radio" name="q3" value="4"><label for="q3">4</label>
                <input type="radio" name="q3" value="3"><label for="q3">3</label>
                <input type="radio" name="q3" value="2"><label for="q3">2</label>
                <input type="radio" name="q3" value="1"><label for="q3">1</label>
            </fieldset>
            
            <fieldset>
                <legend>4. The teacher has been receptive, adaptive, and addresses feedback received from their students</legend>
                <input type="radio" name="q4" value="5"><label for="q4">5</label>
                <input type="radio" name="q4" value="4"><label for="q4">4</label>
                <input type="radio" name="q4" value="3"><label for="q4">3</label>
                <input type="radio" name="q4" value="2"><label for="q4">2</label>
                <input type="radio" name="q4" value="1"><label for="q4">1</label>
            </fieldset>
            
            <fieldset>
                <legend>5. The teacher gives a fair and justifiable evaluation to their students</legend>
                <input type="radio" name="q5" value="5"><label for="q5">5</label>
                <input type="radio" name="q5" value="4"><label for="q5">4</label>
                <input type="radio" name="q5" value="3"><label for="q5">3</label>
                <input type="radio" name="q5" value="2"><label for="q5">2</label>
                <input type="radio" name="q5" value="1"><label for="q5">1</label>
            </fieldset>
            
             <fieldset>
                <legend>6. The teacher's activities have a reasonable load and timeframe allotted to them</legend>
                <input type="radio" name="q6" value="5"><label for="q6">5</label>
                <input type="radio" name="q6" value="4"><label for="q6">4</label>
                <input type="radio" name="q6" value="3"><label for="q6">3</label>
                <input type="radio" name="q6" value="2"><label for="q6">2</label>
                <input type="radio" name="q6" value="1"><label for="q6">1</label>
            </fieldset>
        </form>
    </body>
</html>
