using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.DAL
{
    public class PostGateway:CommonGateway
    {
        public int SavePost(Post post)
        {
            string query = String.Format("INSERT INTO Post VALUES('{0}', '{1}', {2}, {3}, '{4}')",
                post.NewPost, post.Time, post.Visibility, post.UserId, post.UserName);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public int DeletePostById(int postId)
        {
            string query = String.Format("DELETE FROM [Post] WHERE Id={0}",postId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affetctedRow = command.ExecuteNonQuery();
            conn.Close();

            return affetctedRow;
        }
        public List<Post> GetAllPost()
        {
            List<Post> postList = new List<Post>();
            string query = String.Format("SELECT * FROM Post WHERE Visibility=1  ORDER BY [Time] DESC");
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    Post post = new Post();
                    post.Id = Convert.ToInt32(reader["Id"]);
                    post.UserId = Convert.ToInt32(reader["User_Id"]);
                    post.UserName = reader["User_Name"].ToString();
                    post.NewPost = reader["Post"].ToString();
                    post.Time = Convert.ToDateTime(reader["Time"]);
                    postList.Add(post);
                }
            }
            conn.Close();
            return postList;
        }
        public Post GetPostById (int postId)
        {
            Post post = null;
            string query = String.Format("SELECT * FROM Post WHERE Id={0}", postId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    post = new Post();
                    post.Id = Convert.ToInt32(reader["Id"]);
                    post.UserId = Convert.ToInt32(reader["User_Id"]);
                    post.UserName = reader["User_Name"].ToString();
                    post.NewPost = reader["Post"].ToString();
                    post.Time = Convert.ToDateTime(reader["Time"]);
                }
            }
            conn.Close();
            return post;
        }
        public List<Post> GetPostByUserId(int userId, int visibility)
        {

            List<Post> postList = new List<Post>();
            string query = String.Format("SELECT * FROM Post WHERE User_Id={0} AND Visibility={1}  ORDER BY [Time] DESC", 
                userId, visibility);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Post post = new Post();
                    post.Id = Convert.ToInt32(reader["Id"]);
                    post.UserId = Convert.ToInt32(reader["User_Id"]);
                    post.UserName = reader["User_Name"].ToString();
                    post.NewPost = reader["Post"].ToString();
                    post.Time = Convert.ToDateTime(reader["Time"]);

                    postList.Add(post);
                }
            }
            conn.Close();
            return postList;
        }
        public List<Post> GetAllPostByUserId(int userId)
        {

            List<Post> postList = new List<Post>();
            string query = String.Format("SELECT * FROM Post WHERE User_Id={0} ORDER BY [Time] DESC",
                userId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Post post = new Post();
                    post.Id = Convert.ToInt32(reader["Id"]);
                    post.UserId = Convert.ToInt32(reader["User_Id"]);
                    post.UserName = reader["User_Name"].ToString();
                    post.NewPost = reader["Post"].ToString();
                    post.Time = Convert.ToDateTime(reader["Time"]);

                    postList.Add(post);
                }
            }
            conn.Close();
            return postList;
        }
    }
}