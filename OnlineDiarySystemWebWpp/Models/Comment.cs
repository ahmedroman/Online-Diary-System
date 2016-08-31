using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string NewComment { get; set; }
        public DateTime Time { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public String UserName { get; set; }

    }
}