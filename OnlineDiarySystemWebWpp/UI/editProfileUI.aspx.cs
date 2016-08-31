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
    public partial class editProfileUI : System.Web.UI.Page
    {

        UserManager userManager = new UserManager();
        User loggedInUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkLoggedin();
            loggedInUser = (User)Session["User"];

            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null)
                {
                    int userId = Convert.ToInt32(Request.QueryString["UserId"]);
                    loadTextBox(userManager.GetUserById(userId));
                }
                else
                {
                    Response.Redirect("~/UI/Index.aspx");
                }
            }
        }
        private void loadTextBox(User user)
        {
            nameTextBox.Text = user.Name;
            emailTextBox.Text = user.Email;
            usernameTextBox.Text = user.Username;
            passwordTextBox.Text = user.Password;
            confirmPasswordTextbox.Text = user.Password;
            DOBTextBox.Text = user.DOB.ToShortDateString();
            genderDropdownList.SelectedValue = user.Gender;
        }
        private void checkLoggedin()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/UI/LoginUI.aspx");
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Id = Convert.ToInt32(Request.QueryString["UserId"]);
            user.Name = nameTextBox.Text;
            user.Email = emailTextBox.Text;
            user.Username = usernameTextBox.Text;
            user.Password = passwordTextBox.Text;
            user.DOB = Convert.ToDateTime(DOBTextBox.Text);
            user.Gender = genderDropdownList.SelectedValue;

            int affetctedRow = userManager.UpdateUser(user);
            if (affetctedRow > 0)
            {
                nameIDmessage.Attributes.Add("style", "display:block");
                nameMessageP.InnerHtml = "Edited Successfully. ";
                Session["User"] = user;
            }
            else
            {
                nameMessageP.InnerHtml = "Edit Failed. ";
            }
        }


    }
}