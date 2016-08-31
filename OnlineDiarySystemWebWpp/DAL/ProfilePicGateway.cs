using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.DAL
{
    public class ProfilePicGateway:CommonGateway
    {
        public int SaveProfilePic(ProfilePic profilePic )
        {
            command = new SqlCommand("spSaveImage", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter nameparamName = new SqlParameter() { 
                ParameterName = "@Name" ,
                Value = profilePic.Name
            };
            command.Parameters.Add(nameparamName);
            SqlParameter nameparamSize= new SqlParameter()
            {
                ParameterName = "@Size",
                Value = profilePic.Size
            };
            command.Parameters.Add(nameparamSize);
            SqlParameter nameparamImageData = new SqlParameter()
            {
                ParameterName = "@ImageData",
                Value = profilePic.ImageData
            };
            command.Parameters.Add(nameparamImageData);
            SqlParameter nameparamUserId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Value = profilePic.UserId
            };
            command.Parameters.Add(nameparamUserId);
            SqlParameter nameparamNewId = new SqlParameter()
            {
                ParameterName = "@NewId",
                Value = -1,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(nameparamNewId);

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();

            return Convert.ToInt32(command.Parameters["@NewId"].Value);
        }
        public ProfilePic GetProPicById(int id)
        {
            ProfilePic profilePic = null;
            command = new SqlCommand("spGetImageById", conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter() {
                ParameterName = "@Id",
                Value = id
            };
            command.Parameters.Add(paramId);

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    profilePic = new ProfilePic();
                    profilePic.Id = Convert.ToInt32(reader["Id"]);
                    profilePic.Name = reader["Name"].ToString();
                    profilePic.Size = Convert.ToInt32(reader["Size"]);
                    profilePic.ImageData = (byte[])reader["ImageData"];
                    profilePic.UserId = Convert.ToInt32(reader["UserId"]);
                }
            }
            conn.Close();
            return profilePic;
        }
    }
}