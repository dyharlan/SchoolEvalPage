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
        <h1>Hello ${STU_NUM}, ${STU_NAME}!</h1>
        
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
<!--             <h2>Evaluated teachers:</h2>-->
                ${evaluated_teachers}
<!--             <h2>Unevaluated teachers:</h2>-->
                <p>${unevaluated_teachers}</p>
        <form action="Logout" >
            <pre>
                <input type="submit" Value="Logout">
            </pre>
        </form>
    </body>
</html>
