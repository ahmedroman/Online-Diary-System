using OnlineDiarySystemWebWpp.DAL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.BLL
{
    public class CommentManager
    {
        CommentGateway commentGateway = new CommentGateway();

        public int SaveComment(Comment comment) 
        {
            return commentGateway.SaveComment(comment);
        }
        public List<Comment> GetCommentsByPostId(int postId)
        {
            return commentGateway.GetCommentsByPostId(postId);
        }
    }
}