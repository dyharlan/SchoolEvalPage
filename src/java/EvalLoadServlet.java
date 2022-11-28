/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.*;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author dyhar
 */
public class EvalLoadServlet extends HttpServlet {
    Connection conn;
    PreparedStatement ps;
    ResultSet rs;
    Statement stmt;
    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
//        response.setContentType("text/html;charset=UTF-8");
//        try ( PrintWriter out = response.getWriter()) {
//            /* TODO output your page here. You may use following sample code. */
//            out.println("<!DOCTYPE html>");
//            out.println("<html>");
//            out.println("<head>");
//            out.println("<title>Servlet EvalLoadServlet</title>");            
//            out.println("</head>");
//            out.println("<body>");
//            out.println("<h1>Servlet EvalLoadServlet at " + request.getContextPath() + "</h1>");
//            out.println("</body>");
//            out.println("</html>");
//        }
        String driver = "com.mysql.cj.jdbc.Driver";
        try {
            Class.forName(driver);
            System.out.println("Driver successfully loaded.");
        } catch (ClassNotFoundException cnfe) {
            response.sendError(500, "An unexpected error has occured!: " + cnfe.toString());
        }
        //open connection
        String url = "jdbc:mysql://localhost:3310?zeroDateTimeBehavior=CONVERT_TO_NULL&useSSL=false";
        String username = "root";
        String password = "toorenia";

        try {
            conn = DriverManager.getConnection(url, username, password);
            System.out.println("Connected to: " + url);
        } catch (SQLException sqle) {
            response.sendError(500, "An unexpected error has occured!: " + sqle.toString());
        }
        RequestDispatcher dispatcher;
        HttpSession session = request.getSession();
        StringBuilder evaluated_teachers = new StringBuilder();
        StringBuilder unevaluated_teachers = new StringBuilder();

        try{
            stmt = conn.createStatement();
            String cmd1 = "USE evaluation";
            stmt.execute(cmd1);
            //set parameterized query
            String evaluated_query = "select person.fname, person.lname, eval_status.teacher_num, eval_status.course_code, course_offerings.course_name FROM eval_status left join teacher on eval_status.teacher_num = teacher.teacher_num left join person on teacher.person_id = person.person_id left join course_offerings on eval_status.course_code = course_offerings.course_code where eval_status.stu_num = ?;";
            String unevaluated_query = "SELECT person.fname, person.lname, course_assignments.teacher_num, course_assignments.course_code, course_offerings.course_name FROM course_assignments \n" +
"left join eval_status on course_assignments.teacher_num = eval_status.teacher_num and course_assignments.course_code = eval_status.course_code and eval_status.stu_num = (select stu_num from class_student_list where stu_num = ?) \n" +
"left join teacher on course_assignments.teacher_num = teacher.teacher_num left join person on teacher.person_id = person.person_id\n" +
"left join course_offerings on course_assignments.course_code = course_offerings.course_code\n" +
"where class_code = (select class_code from class_student_list where stu_num = ?) \n" +
" and eval_status.teacher_num is null and eval_status.course_code is null order by course_code asc;";
            
            //retrieve preparedStatement obj from conn
            ps = conn.prepareStatement(evaluated_query);
            ps.setString(1, (String) session.getAttribute("STU_NUM"));
            
            ResultSet rs = ps.executeQuery();
//            while(rs.next()){
//                teacher_info.append("<tr>" + "\n");
//                teacher_info.append("<td>" + rs.getString("class_code") + "</td>\n");
//                teacher_info.append("<td>" + rs.getString("TEACHER_NUM") + "</td>\n");
//                teacher_info.append("<td>" + rs.getString("course_code") + "</td>\n");
//                teacher_info.append("<td>" + rs.getString("FNAME") + "</td>\n");
//                teacher_info.append("<td>" + rs.getString("LNAME") + "</td>\n");
//                teacher_info.append("<td>" + rs.getString("DOB") +"</td>\n");
//                teacher_info.append("</tr>" + "\n");
//            }
            while(rs.next()){
                evaluated_teachers.append("<p> Name: " + rs.getString("FNAME") + " " + rs.getString("LNAME") + "<br>Course: " + rs.getString("course_code") + " - " + rs.getString("course_name") +"</p>\n");

            }
            ps = conn.prepareStatement(unevaluated_query);
            ps.setString(1, (String) session.getAttribute("STU_NUM"));
            ps.setString(2, (String) session.getAttribute("STU_NUM"));
            rs = ps.executeQuery();
            while(rs.next()){
                unevaluated_teachers.append("<a href=\"form.jsp?teacher_num=" + rs.getString("teacher_num") + "&course_code=" + rs.getString("course_code") + "\">" + "Name: " + rs.getString("FNAME") + " " + rs.getString("LNAME") + "<br>Course: " + rs.getString("course_code") + " - " + rs.getString("course_name") +"</a><br>\n");
            }
            stmt.close();
            rs.close();
            ps.close();
            conn.close();
            session.setAttribute("evaluated_teachers", evaluated_teachers);
            session.setAttribute("unevaluated_teachers", unevaluated_teachers);

            dispatcher = request.getRequestDispatcher("eval.jsp");
            dispatcher.forward(request,response);
            
        }
        catch(SQLException sqle){
            response.sendError(500, "An unexpected error has occured!: " + sqle.toString());
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
