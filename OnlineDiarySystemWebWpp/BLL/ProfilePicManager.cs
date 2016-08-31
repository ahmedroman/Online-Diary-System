using OnlineDiarySystemWebWpp.DAL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.BLL
{
    public class ProfilePicManager
    {
        ProfilePicGateway profilePicGateway = new ProfilePicGateway();
        public int SaveProfilePic(ProfilePic profilePic)
        {
            return profilePicGateway.SaveProfilePic(profilePic);
        }
        public ProfilePic GetProPicById(int id)
        {
            return profilePicGateway.GetProPicById(id);
        }
    }

}