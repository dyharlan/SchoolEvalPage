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
        <link rel="stylesheet" href="login.css">
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet">
    </head>
    <body>
        <%
            response.setHeader("Cache-Control", "no-cache, no-store, must-revalidate"); //http 1.1+
            response.setHeader("Pragma", "no-cache"); //http 1.0
            response.setHeader("Expires", "0"); //for proxy
            if(session.getAttribute("STU_NUM") != null)
                response.sendRedirect("eval.jsp");
        %>
        <main>
            <div class="form-container">
                <div class="login-form">
                    <form action="Login" METHOD="POST"> 
                        <label for="userid">Enter Student No.: </label><input id="userid" type="text" name="userid" required><br>
                        <br>
                        <input type="submit" Value="Login"> 
                    </form>
                </div>
            </div>
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
