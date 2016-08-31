using OnlineDiarySystemWebWpp.BLL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiarySystemWebWpp.UI
{
    public partial class CommentUI : System.Web.UI.Page
    {
        PostManager postManager = new PostManager();
        CommentManager commentManager = new CommentManager();
        User loggedInUser;
        int postId;
        protected void Page_Load(object sender, EventArgs e)
        {
            checkLoggedin();
            loggedInUser = (User)Session["User"];

            if (!IsPostBack)
            {
                if (Request.QueryString["postId"] != null)
                {
                    postId = Convert.ToInt32(Request.QueryString["postId"]);
                    Post post = postManager.GetPostById(postId);
                    LoadPost(post);
                    LoadCommentGridView(commentManager.GetCommentsByPostId(postId));
                    if (post.UserId == loggedInUser.Id) 
                    {
                        deleteHyperLink.Visible = true;
                        deleteHyperLink.NavigateUrl = String.Format("~/UI/DeleteUI.aspx?postId={0}", post.Id);
                    }
                }
            }
        }
        private void LoadPost(Post post)
        {
            nameLink.NavigateUrl = String.Format("~/UI/UserProfileUI.aspx?UserId={0}", post.UserId);
            nameLink.Text = post.UserName;
            postLabel.Text = post.NewPost;
            timeLabel.NavigateUrl = String.Format("/UI/CommentUI.aspx?postId={0}",post.Id);
            timeLabel.Text = post.Time.ToString("dd MMM yyyy");
        }
        private void LoadCommentGridView(List<Comment> commentList)
        {
            commentsGridView.DataSource = commentList;
            commentsGridView.DataBind();
        }
        private void checkLoggedin()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/UI/LoginUI.aspx");
            }
        }

        protected void postCommentButton_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment();
            comment.NewComment = commentTextbox.Text;
            comment.Time = DateTime.Now;
            comment.PostId = Convert.ToInt32(Request.QueryString["PostId"]);
            comment.UserId = loggedInUser.Id;
            comment.UserName = loggedInUser.Name;
            commentManager.SaveComment(comment);

            if (Request.UrlReferrer != null) 
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }


    }
}