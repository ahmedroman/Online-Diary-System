using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.DAL
{
    public class FollowGateway:CommentGateway
    {
        public int SaveFollow(Follow follow)
        {
            string query = String.Format("INSERT INTO [Follow] VALUES({0}, {1}, '{2}')",
                   follow.PersonId, follow.FollowerId, follow.FollowerName);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affrectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affrectedRow;
        }
        public List<Follow> GetFollowerByPersonId(int userId)
        {

            List<Follow> followerList = new List<Follow>();
            string query = String.Format("SELECT * FROM [Follow] WHERE Follower_Id={0}", userId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Follow follower = new Follow();
                    follower.PersonId = Convert.ToInt32(reader["Person_Id"]);
                    follower.FollowerId = Convert.ToInt32(reader["Follower_Id"]);
                    follower.FollowerName = reader["Follower_Name"].ToString();

                    followerList.Add(follower);
                }
            }
            conn.Close();
            return followerList;
        }
        public Follow CheckFollower(int userId, int followerId)
        {

            Follow follower = null;
            string query = String.Format("SELECT * FROM [Follow] WHERE Follower_Id={0} AND Person_Id={1}",followerId, userId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    follower = new Follow();
                    follower.PersonId = Convert.ToInt32(reader["Person_Id"]);
                    follower.FollowerId = Convert.ToInt32(reader["Follower_Id"]);
                    follower.FollowerName = reader["Follower_Name"].ToString();
                }
            }
            conn.Close();
            return follower;
        }
        public List<Follow> GetFollowerCountOfPerson(int userId)
        {

            List<Follow> followerList = new List<Follow>();
            string query = String.Format("SELECT * FROM [Follow] WHERE Person_Id={0}", userId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Follow follower = new Follow();
                    follower.PersonId = Convert.ToInt32(reader["Person_Id"]);
                    follower.FollowerId = Convert.ToInt32(reader["Follower_Id"]);
                    follower.FollowerName = reader["Follower_Name"].ToString();

                    followerList.Add(follower);
                }
            }
            conn.Close();
            return followerList;
        }
        public int UnFollow(int personId, int followerId)
        {
            string query = String.Format("DELETE FROM [Follow] WHERE Person_Id={0} AND Follower_Id={1}",
                   personId, followerId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affrectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affrectedRow;
        }

    }
}