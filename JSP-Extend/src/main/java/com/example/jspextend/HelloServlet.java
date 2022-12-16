package com.example.jspextend;
import java.io.*;
import java.sql.*;
import java.util.HashMap;
import java.util.LinkedList;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebServlet(name = "all-user", value = "/all-user")
public class HelloServlet extends HttpServlet {
    private String message;

    public void init() {
        message = "Hello World!";
    }
    public LinkedList<String> getUsers(){
        LinkedList<String> user = new LinkedList<String>();
        Connection connection= dbstore.getConnection();
        ResultSet rs= null;
        try {
            Statement statement=connection.createStatement();
            rs = statement.executeQuery("select * from user");
            System.out.println("poggers bro");
            while(rs.next()) {
                System.out.println(rs.getString(2));
                user.add(rs.getString(2));
            }
            connection.close();
            return user;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return null;
    }
    public LinkedList<String> getMessages(){
        LinkedList<String> message = new LinkedList<String>();
        Connection connection= dbstore.getConnection();
        ResultSet rs= null;
        try {
            Statement statement=connection.createStatement();
            rs = statement.executeQuery("select user.username, message.text, message.posted_at from message INNER JOIN user ON message.user_id=user.id;");
            System.out.println("poggers bro");
            while(rs.next()) {
                System.out.println(rs.getString(2));
                message.add(rs.getString(2));
            }
            connection.close();
            return message;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return null;
    }



    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {

        getUsers();
        try {
            request.setAttribute("users", getUsers());
            request.setAttribute("messages", getMessages());

            request.getRequestDispatcher("activeusers.jsp").forward(request,response);
        } catch (Exception e) {
            e.printStackTrace();
        }
//        response.setContentType("text/html");
//        // Hello
//        PrintWriter out = response.getWriter();
//        out.println("<html><body>");
//        out.println("<h1>" + message + "</h1>");
//        out.println("</body></html>");

    }

    public void destroy() {
    }
}