using OnlineDiarySystemWebWpp.BLL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiarySystemWebWpp.Controls
{
    public partial class Header : System.Web.UI.UserControl
    {
        User loggedInUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInUser = (User)Session["User"];
            
            usernameLink.Text = loggedInUser.Name;
            usernameLink.NavigateUrl = String.Format("~/UI/UserProfileUI.aspx?UserId={0}", loggedInUser.Id);

        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/UI/LoginUI.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/UI/SearchUI.aspx?search={0}", searchTextBox.Text));
        }

    }
}