package com.example.jspextend;

import java.sql.*;
import java.util.LinkedList;

public class dbstore {


    public static void main(String[] args) {
        try {
            Connection connection;
            connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/chatapp","root","");
            Statement statement=connection.createStatement();
            ResultSet rs= statement.executeQuery("select * from message");
            while(rs.next())
                System.out.println(rs.getString(2));
            connection.close();
        } catch (SQLException  e) {
            throw new RuntimeException(e);

        }
    }

     public static Connection getConnection(){
         try {
             DriverManager.registerDriver(new com.mysql.jdbc.Driver());
             Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/chatapp","root","");
             return connection;
         } catch (SQLException e) {
             System.out.println(e.getMessage());
         }
         return null;
     }
}
