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
    public partial class LoginUI : System.Web.UI.Page
    {
        UserManager userManager = new UserManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            User foundUser = userManager.CheckUser(username, password);
            if (foundUser != null)
            {
                Session["User"] = foundUser;
                Response.Redirect("~/UI/Index.aspx");
            }
            else 
            {
                Session["User"] = foundUser;
                usernameIDmessage.Attributes.Add("style","display:block");
                messageP.InnerText = "Invalid Username/password";
            }
        }
    }
}