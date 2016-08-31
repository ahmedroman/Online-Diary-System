using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.Models
{
    public class ProfilePic
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public int Size{get;set;}
        public byte[] ImageData{get;set;}
        public int UserId { get; set; }
      
    }
}