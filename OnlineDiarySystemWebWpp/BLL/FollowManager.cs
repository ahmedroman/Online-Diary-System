using OnlineDiarySystemWebWpp.DAL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.BLL
{
    public class FollowManager
    {
        FollowGateway followGateway = new FollowGateway();
        public int SaveFollow(Follow follow)
        {
            return followGateway.SaveFollow(follow);
        }
        public List<Follow> GetFollowerByPersonId(int userId)
        {
            return followGateway.GetFollowerByPersonId(userId);
        }
        public Follow CheckFollower(int userId, int followerId)
        {
            return followGateway.CheckFollower(userId, followerId);
        }
        public List<Follow> GetFollowerCountOfPerson(int userId)
        {
            return followGateway.GetFollowerCountOfPerson(userId);
        }
        public int UnFollow(int personId, int followerId)
        {
            return followGateway.UnFollow(personId, followerId);
        }


    }
}