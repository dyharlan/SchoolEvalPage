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
            if (session.getAttribute("STU_NUM") == null)
                response.sendRedirect("login.jsp");
        %>
        <main>
            <nav id="navbar">

                <ul>
                    <li><h1>Hello ${STU_NUM}, ${STU_NAME}!</h1></li>
                </ul>
                <ul class="pull-right">
                    <li><form action="Logout"> 
                            <input type="submit" Value="Logout"> 
                        </form></li>
                </ul>
            </nav>
            
            <div class="container">
                <h2>Course Teachers for evaluation:</h2>
                ${evaluated_teachers}
                ${unevaluated_teachers}
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
