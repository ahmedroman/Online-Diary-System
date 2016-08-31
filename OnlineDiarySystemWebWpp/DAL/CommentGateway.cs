using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.DAL
{
    public class CommentGateway:CommonGateway
    {
        public int SaveComment(Comment comment)
        {
            string query = String.Format("INSERT INTO Comment VALUES('{0}', '{1}', {2}, {3}, '{4}')",
            comment.NewComment, comment.Time, comment.PostId, comment.UserId, comment.UserName);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public List<Comment> GetCommentsByPostId(int postId)
        {
            List<Comment> commentList = new List<Comment>();
            string query = String.Format("SELECT * FROM Comment WHERE Post_Id={0}", postId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    Comment comment = new Comment();
                    comment.Id = Convert.ToInt32(reader["Id"]);
                    comment.NewComment = reader["Comment"].ToString();
                    comment.Time = Convert.ToDateTime(reader["Time"]);
                    comment.PostId = Convert.ToInt32(reader["Post_Id"]);
                    comment.UserId = Convert.ToInt32(reader["User_Id"]);
                    comment.UserName = reader["User_Name"].ToString();
                    commentList.Add(comment);
                }
            }
            conn.Close();
            return commentList;
        }
    }
}