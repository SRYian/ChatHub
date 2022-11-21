using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatHub.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
namespace ChatHub.Config
{
    public class DBStore:DbContext
    {

        public string ConnectionString { get; set; }

        public DBStore(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }


        public List<Message> GetAllMessage()
        {
            List<Message> list = new List<Message>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string cmdstring = "select user.username, message.text, message.posted_at from message INNER JOIN user ON message.user_id=user.id;";

                MySqlCommand cmd = new MySqlCommand(cmdstring, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Message()
                        {
                            //Id = Convert.ToInt32(reader["id"]),
                            Username = reader["username"].ToString(),
                            Text = reader["text"].ToString(),
                            Date = Convert.ToDateTime(reader["posted_at"]), 
                        });;
                    }
                }
                conn.Close();
            }
            return list;
        }


        public void SendMessage(Message message)
        {
            

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string cmdstring = "INSERT INTO `message`(`text`, `user_id`) VALUES ('"+message.Text+"','"+ message.UserID + "');";
                string cmdstring2 = "INSERT INTO `message`(`text`, `user_id`) VALUES ('" + message.Text + "', (select user.id from user WHERE user.username='" + message.Username + "'))";

                MySqlCommand cmd = new MySqlCommand(cmdstring2, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
        }
        public void CreateUser(string username, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string cmdstring = "INSERT INTO `user`(`username`, `password`) VALUES ('" + username + "','" + password + "');";
                
                MySqlCommand cmd = new MySqlCommand(cmdstring, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public string getUserID(string id)
        {
            string name="";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string cmdstring = "select user.username from user WHERE user.id="+id+";";

                MySqlCommand cmd = new MySqlCommand(cmdstring, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        name = reader["username"].ToString();
                    }
                }
                conn.Close();
            }
            return name;
        }
        public User getValidation(string username)
        {
            
            User user = new User();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string cmdstring = "select id, username, password from user WHERE user.username='" + username + "';";

                MySqlCommand cmd = new MySqlCommand(cmdstring, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        user.Username = reader["username"].ToString();
                        user.Password = reader["password"].ToString();
                    }
                }
                conn.Close();
            }
            return user;
        }


    }
}
