/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.util.UUID;

/**
 *
 * @author dyhar
 */
public class EvalProcessor extends HttpServlet {
    Connection conn;
    PreparedStatement ps;
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
        response.setContentType("text/html;charset=UTF-8");
        try ( PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet EvalProcessor</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet EvalProcessor at " + request.getContextPath() + "</h1>");
            out.println("</body>");
            out.println("</html>");
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
        //processRequest(request, response);
        String driver = "com.mysql.cj.jdbc.Driver";
        try{
             Class.forName(driver);
             System.out.println("Driver successfully loaded.");
        }
        catch(ClassNotFoundException cnfe){
            System.err.println("Driver not found or not loaded. ");
        }
        //open connection
        String url = "jdbc:mysql://localhost:3310?zeroDateTimeBehavior=CONVERT_TO_NULL&useSSL=false";
        String username = "root";
        String password = "toorenia";
        
        try{
            conn = DriverManager.getConnection(url, username, password);
            System.out.println("Connected to: " + url);
        }
        catch(SQLException sqle){
            System.err.println("An unexpected error occured! " + sqle.toString());
        }
        RequestDispatcher dispatcher;
        HttpSession session = request.getSession();
        
        try{
            //open DB
            stmt = conn.createStatement();
            String cmd1 = "USE evaluation";
            stmt.execute(cmd1);
            //set parameterized query
            String ps_query = "CALL evaluate_teacher(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            //retrieve preparedStatement obj from conn
            ps = conn.prepareStatement(ps_query);
            String student_id = (String) session.getAttribute("STU_NUM");
            String teacher_id = request.getParameter("teacher_num");
            String course_code = request.getParameter("course_code");
            UUID uuid = UUID.randomUUID();
            String form_code = uuid.toString();
            System.out.println("form code: " + form_code);
            System.out.println(student_id);
            System.out.println(teacher_id);
            System.out.println(course_code);
            ps.setString(1, student_id);
            ps.setString(2, teacher_id);
            ps.setString(3, course_code);
            ps.setString(4, form_code);
            ps.setInt(5, Integer.parseInt(request.getParameter("q1")));
            ps.setInt(6, Integer.parseInt(request.getParameter("q2")));
            ps.setInt(7, Integer.parseInt(request.getParameter("q3")));
            ps.setInt(8, Integer.parseInt(request.getParameter("q4")));
            ps.setInt(9, Integer.parseInt(request.getParameter("q5")));
            ps.setInt(10, Integer.parseInt(request.getParameter("q6")));
            ps.setInt(11, Integer.parseInt(request.getParameter("q7")));
            ps.setInt(12, Integer.parseInt(request.getParameter("q8")));
            ps.setInt(13, Integer.parseInt(request.getParameter("q9")));
            ps.setInt(14, Integer.parseInt(request.getParameter("q10")));
            //disable autocommit for transaction mode
            conn.setAutoCommit(false);
            //execute parameterized query
            
            try{
                ps.executeUpdate();
                conn.commit();
            }
            catch(SQLException ex){
                conn.rollback();
                throw ex;
            }
            finally{
                conn.setAutoCommit(true);
            }
            stmt.close();
            ps.close();
            conn.close();    
            response.sendRedirect("eval.jsp");
            
        }
        catch(SQLException sqle){
            response.sendError(500, "An unexpected error has occured!: " + sqle.toString());
        }
        
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
