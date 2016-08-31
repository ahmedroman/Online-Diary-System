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
    public partial class FollowUI : System.Web.UI.Page
    {
        FollowManager followManager = new FollowManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UnFollow"] != null && 
                    Request.QueryString["PersonId"] != null)
                {
                    int personId = Convert.ToInt32(Request.QueryString["UnFollow"]);
                    int followerId = Convert.ToInt32(Request.QueryString["PersonId"]);
                    followManager.UnFollow(personId, followerId);
                }
                else if (Request.QueryString["FollowerId"] != null &&
                    Request.QueryString["FollowerName"] != null &&
                    Request.QueryString["PersonId"] != null)
                {
                    Follow follow = new Follow();
                    follow.PersonId = Convert.ToInt32(Request.QueryString["PersonId"]);
                    follow.FollowerId = Convert.ToInt32(Request.QueryString["FollowerId"]);

                    follow.FollowerName = Request.QueryString["FollowerName"];

                    followManager.SaveFollow(follow);



                }
                //pervious page
                if (Request.UrlReferrer != null)

                    Response.Redirect(Request.UrlReferrer.ToString());

            }
        }
    }
}