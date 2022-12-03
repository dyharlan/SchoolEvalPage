<%-- 
    Document   : eval-page
    Created on : 26 Nov 2022, 8:47:45 pm
    Author     : dyhar
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="loader.DataLoader"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Please select a teacher to evaluate</title>
        <link rel="stylesheet" href="eval.css">
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet">
    </head>
    <body>
        <%
            DataLoader ev = new DataLoader();
            ev.load_data(request, response);
            response.setHeader("Cache-Control", "no-cache, no-store, must-revalidate"); //http 1.1+
            response.setHeader("Pragma", "no-cache"); //http 1.0
            response.setHeader("Expires", "0"); //for proxy
            if(session.getAttribute("STU_NUM") == null)
                response.sendRedirect("login.jsp");
        %>
        <h1>Name: ${STU_NAME}</h1>
        <h1>Student Number: ${STU_NUM}</h1>
        
<!--            <table>
            <tr>
                <th>Class Code</th>
                <th>Teacher Code</th>
                <th>Course Code</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Date of Birth</th>
            </tr>
             
            </table>-->
            <h2>Evaluated Teachers:</h2>
            <div class="eval">
                ${evaluated_teachers}
            </div>
            <h2>Unevaluated Teachers:</h2>
            <div class="uneval">
                ${unevaluated_teachers}
            </div>
        <form action="Logout" >
            <pre>
                <input type="submit" Value="Logout">
            </pre>
        </form>
    </body>
</html>
