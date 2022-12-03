/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.ServletConfig;
import javax.servlet.http.HttpSession;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 *
 * @author dyhar
 */
import java.sql.*;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletContext;
public class LoginServlet extends HttpServlet {
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
        response.setContentType("text/html;charset=UTF-8");
        try ( PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet LoginServlet</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet LoginServlet at " + request.getContextPath() + "</h1>");
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
        ServletContext sct = request.getServletContext();
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
        String username = sct.getInitParameter("username");
        String password = sct.getInitParameter("password");
        
        try{
            conn = DriverManager.getConnection(url, username, password);
            System.out.println("Connected to: " + url);
        }
        catch(SQLException sqle){
            System.err.println("An unexpected error occured! " + sqle.toString());
        }
        String userid = request.getParameter("userid");
        //String password = request.getParameter("password");
        RequestDispatcher dispatcher;
        HttpSession session = request.getSession();
        
        try{
            //open DB
            stmt = conn.createStatement();
            String cmd1 = "USE evaluation";
            stmt.execute(cmd1);
            //set parameterized query
            String ps_query = "CALL open_student_info(?)";
            //retrieve preparedStatement obj from conn
            ps = conn.prepareStatement(ps_query);
            String student_id = request.getParameter("userid");
            ps.setString(1, student_id);
            //execute parameterized query
            ResultSet rs = ps.executeQuery();
            String stu_name = null;
            String stu_num  = null;
            while(rs.next()){
                stu_num = rs.getString("STU_NUM");
                stu_name = rs.getString("FNAME") + " " + rs.getString("LNAME");
            }
            stmt.close();
            rs.close();
            ps.close();
            conn.close();
            if(stu_num == null || !(student_id.equals(stu_num)) ){
                dispatcher = request.getRequestDispatcher("login.jsp");
                session.setAttribute("failure","Invalid User ID has been inputted. Please try again.");
                dispatcher.include(request,response);
            }
            else if(student_id.equals(stu_num)){   
                session.setAttribute("STU_NUM", stu_num);
                session.setAttribute("STU_NAME", stu_name);
                
                if (session.getAttribute("failure") != null)
                    session.removeAttribute("failure");
                dispatcher = request.getRequestDispatcher("eval.jsp");
                dispatcher.forward(request,response);
            }
        }
        catch(SQLException sqle){
            response.sendError(500, "An unexpected error has occured!: " + sqle.toString());
        }
        
    }
    @Override
    public void init (ServletConfig config) throws ServletException{
           super.init(config);
       
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
