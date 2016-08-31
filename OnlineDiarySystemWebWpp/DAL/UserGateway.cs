using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.DAL
{
    public class UserGateway:CommonGateway
    {
        public User GetUserById(int userId)
        {
            User user = null;
            string query = String.Format("SELECT * FROM [User] WHERE Id={0}", userId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    user = new User();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Name = reader["Name"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Username = reader["Username"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.DOB = Convert.ToDateTime(reader["DOB"]);
                    user.Gender = reader["Gender"].ToString();
                    user.ProPicId = Convert.ToInt32(reader["ProPicId"]);
                }
            }
            conn.Close();
            return user;

        }
        public int SaveUser(User user) 
        {
            string query = String.Format("INSERT INTO [User] VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}',{6})",
                user.Name, user.Email, user.Username, user.Password, user.DOB, user.Gender,user.ProPicId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affrectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affrectedRow;
        }
        public User GetUserByUsername(string username)
        {
            User user = null;
            string query = String.Format("SELECT * FROM [User] WHERE Username='{0}'", username);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = new User();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Name = reader["Name"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Username = reader["Username"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.DOB = Convert.ToDateTime(reader["DOB"]);
                    user.Gender = reader["Gender"].ToString();
                    user.ProPicId = Convert.ToInt32(reader["ProPicId"]);
                }
            }
            conn.Close();
            return user;

        }
        public int UpdateUser(User user)
        {
            string query = String.Format("UPDATE [User] SET Name='{0}', Email='{1}', Username='{2}', Password='{3}', DOB='{4}', Gender='{5}' WHERE Id = {6}",
                user.Name, user.Email, user.Username, user.Password, user.DOB, user.Gender, user.Id);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affrectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affrectedRow;
        }
        public List<User> GetUserByName(string name)
        {
            List<User> userList = new List<User>();
            string query = String.Format("SELECT * FROM [User] WHERE Name LIKE '%{0}%'", name);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Name = reader["Name"].ToString();
                    user.Email = reader["Email"].ToString();
                    //user.Username = reader["Username"].ToString();
                    //user.Password = reader["Password"].ToString();
                    user.DOB = Convert.ToDateTime(reader["DOB"]);
                    user.Gender = reader["Gender"].ToString();
                    user.ProPicId = Convert.ToInt32(reader["ProPicId"]);
                    userList.Add(user);
                }
            }
            conn.Close();
            return userList;

        }

        public int UpdateUserWithPic(User user)
        {
            string query = String.Format("UPDATE [User] SET ProPicId={0} WHERE Id = {1}",
                user.ProPicId, user.Id);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affrectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affrectedRow;
        }
    }
}