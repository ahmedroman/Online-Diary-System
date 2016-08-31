using OnlineDiarySystemWebWpp.DAL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.BLL
{
    public class UserManager
    {
        UserGateway userGateway = new UserGateway();
        public User GetUserById(int userId)
        {
            return userGateway.GetUserById(userId);
        }
        public int SaveUser(User user)
        {
            return userGateway.SaveUser(user);
        }
        public User GetUserByUsername(string username)
        {
            return userGateway.GetUserByUsername(username);
        }
        public int UpdateUser(User user)
        {
            return userGateway.UpdateUser(user);
        }
        public List<User> GetUserByName(string name)
        {
            return userGateway.GetUserByName(name);
        }
        public int UpdateUserWithPic(User user)
        {
            return userGateway.UpdateUserWithPic(user);
        }

        public User CheckUser(string username, string password)
        {
            User foundUser = null;
            User user = GetUserByUsername(username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        
    }
}