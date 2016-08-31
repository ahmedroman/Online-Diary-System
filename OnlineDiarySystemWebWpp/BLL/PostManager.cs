using OnlineDiarySystemWebWpp.DAL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineDiarySystemWebWpp.BLL
{
    public class PostManager
    {
        PostGateway postGateway = new PostGateway();
        public int SavePost(Post post)
        {
            return postGateway.SavePost(post);
        }
        public int DeletePostById(int postId)
        {
            return postGateway.DeletePostById(postId);
        }
        public List<Post> GetAllPost()
        {
            return postGateway.GetAllPost();
        }
        public Post GetPostById(int postId)
        {
            return postGateway.GetPostById(postId);
        }
        public List<Post> GetPostByUserId(int userId, int visibility) 
        {
            return postGateway.GetPostByUserId(userId, visibility);
        }
        public List<Post> GetAllPostByUserId(int userId)
        {
            return postGateway.GetAllPostByUserId(userId);
        }
    }
}