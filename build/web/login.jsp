<%-- 
    Document   : login
    Created on : 17 Nov 2022, 11:27:00 am
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
            if(session.getAttribute("STU_NUM") != null)
                response.sendRedirect("eval.jsp");
        %>
        <form action="Login" METHOD="POST">
            <pre>
                Enter: <input type="text" name="userid"><br>
                <!-- <Enter Password: <input type="password" name="password"> --><br>
                <input type="submit" Value="Login">
            </pre>
        </form>
    </body>
</html>
