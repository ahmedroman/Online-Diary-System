using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string NewPost { get; set; }
        public DateTime Time { get; set; }
        public int Visibility { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}