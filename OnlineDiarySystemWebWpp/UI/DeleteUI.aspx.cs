using OnlineDiarySystemWebWpp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiarySystemWebWpp.UI
{
    public partial class DeleteUI : System.Web.UI.Page
    {
        PostManager postManager = new PostManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            checkLoggedin();
            if(!IsPostBack)
            {
                if (Request.QueryString["postId"] != null)
                {
                    int postId = Convert.ToInt32(Request.QueryString["postId"]);
                    postManager.DeletePostById(postId);
                    Response.Redirect("~/UI/Index.aspx");
                }
            }
            if (Request.UrlReferrer != null)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
        private void checkLoggedin()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/UI/LoginUI.aspx");
            }
        }



    }
}