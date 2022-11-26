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
            System.err.println("Driver not found or not loaded. ");
        }
        //open connection
        String url = "jdbc:mysql://localhost:3310?zeroDateTimeBehavior=CONVERT_TO_NULL&useSSL=false";
        String username = "root";
        String password = "toorenia";

        try {
            conn = DriverManager.getConnection(url, username, password);
            System.out.println("Connected to: " + url);
        } catch (SQLException sqle) {
            System.err.println("An unexpected error occured! " + sqle.toString());
        }
        RequestDispatcher dispatcher;
        HttpSession session = request.getSession();
        StringBuilder teacher_info = new StringBuilder();
        try{
            stmt = conn.createStatement();
            String cmd1 = "USE evaluation";
            stmt.execute(cmd1);
            //set parameterized query
            String ps_query = "SELECT course_assignment.class_code, teacher.TEACHER_CODE, person.FNAME, person.LNAME,AGE FROM EVALUATION.PERSON LEFT JOIN EVALUATION.TEACHER ON person.person_id = teacher.person_id LEFT JOIN EVALUATION.COURSE_ASSIGNMENT ON TEACHER.TEACHER_CODE = COURSE_ASSIGNMENT.TEACHER_CODE where TEACHER.teacher_code is not null and TEACHER.teacher_code in (SELECT TEACHER_CODE FROM course_assignment \n" +
"where class_code = (select class_code from class_assignment where stu_num = ?)) AND course_assignment.class_code = (select class_code from class_assignment where stu_num = ?) order by person.person_id asc";
            //retrieve preparedStatement obj from conn
            ps = conn.prepareStatement(ps_query);
            ps.setString(1, (String) session.getAttribute("STU_NUM"));
            ps.setString(2, (String) session.getAttribute("STU_NUM"));
            ResultSet rs = ps.executeQuery();
            while(rs.next()){
                teacher_info.append("<tr>" + "\n");
                teacher_info.append("<td>" + rs.getString("class_code") + "</td>\n");
                teacher_info.append("<td>" + rs.getString("TEACHER_CODE") + "</td>\n");
                teacher_info.append("<td>" + rs.getString("FNAME") + "</td>\n");
                teacher_info.append("<td>" + rs.getString("LNAME") + "</td>\n");
                teacher_info.append("<td>" + rs.getString("AGE") +"</td>\n");
                teacher_info.append("</tr>" + "\n");
            }
            stmt.close();
            rs.close();
            ps.close();
            conn.close();
            session.setAttribute("teacher_info", teacher_info);
            dispatcher = request.getRequestDispatcher("eval.jsp");
            dispatcher.forward(request,response);
            
        }
        catch(SQLException sqle){
            System.err.println("An unexpected error occured! " + sqle.toString());
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
