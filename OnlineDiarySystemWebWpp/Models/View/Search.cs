using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.Models.View
{
    public class Search
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string ProPic { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public int Age { get; set; }
        public string FollowButtonText { get; set; }
        public string NavigateUrl{ get; set; }
        public string NavigateUrlFollower { get; set; }
        public string NavigateUrlFollowing { get; set; }
    }
}