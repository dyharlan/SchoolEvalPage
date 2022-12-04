/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */

package loader;
import java.io.IOException;
import java.sql.*;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletConfig;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author dyhar
 */
public class DataLoader {
    Connection conn;
    PreparedStatement ps;
    ResultSet rs;
    Statement stmt;
    
    
    public void load_data(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException{
        ServletContext sct = request.getServletContext();
        String driver = "com.mysql.cj.jdbc.Driver";
        try {
            Class.forName(driver);
            System.out.println("Driver successfully loaded.");
        } catch (ClassNotFoundException cnfe) {
            response.sendError(500, "An unexpected error has occured!: " + cnfe.toString());
        }
        //open connection
        String url = "jdbc:mysql://localhost:3310?zeroDateTimeBehavior=CONVERT_TO_NULL&useSSL=false";
        String username = sct.getInitParameter("username");
        String password = sct.getInitParameter("password");

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
            //open DB
            stmt = conn.createStatement();
            String cmd1 = "USE evaluation";
            stmt.execute(cmd1);
            //set parameterized query
            String evaluated_query = "call view_evaluated_teachers(?)";
            String unevaluated_query = "call view_unevaluated_teachers(?)";
            
            //retrieve preparedStatement obj from conn
            ps = conn.prepareStatement(evaluated_query);
            ps.setString(1, (String) session.getAttribute("STU_NUM"));
            
            
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
            ResultSet rs = ps.executeQuery();
            while(rs.next()){
                evaluated_teachers.append("<p> Name: " + rs.getString("FNAME") + " " + rs.getString("LNAME") + "<br>Course: " + rs.getString("course_code") + " - " + rs.getString("course_name") +"</p>\n");

            }
            ps = conn.prepareStatement(unevaluated_query);
            ps.setString(1, (String) session.getAttribute("STU_NUM"));
            rs = ps.executeQuery();
            while(rs.next()){
                unevaluated_teachers.append("<a href=\"form.jsp?teacher_num=" + rs.getString("teachers_code") + "&course_code=" + rs.getString("course_code") + "&FName=" + rs.getString("FNAME") + "&LName=" + rs.getString("LNAME") + "\">" + "Name: " + rs.getString("FNAME") + " " + rs.getString("LNAME") + "<br>Course: " + rs.getString("course_code") + " - " + rs.getString("course_name") +"</a><br>\n");
            }
            stmt.close();
            rs.close();
            ps.close();
            conn.close();
            session.setAttribute("evaluated_teachers", evaluated_teachers);
            session.setAttribute("unevaluated_teachers", unevaluated_teachers);

           
            
        }
        catch(SQLException sqle){
            response.sendError(500, "An unexpected error has occured!: " + sqle.toString());
        }
    }


}
