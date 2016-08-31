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
    public partial class RegisterUI : System.Web.UI.Page
    {
        UserManager userManager = new UserManager();
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = nameTextBox.Text;
            user.Email = emailTextBox.Text;
            user.Username = usernameTextBox.Text;
            user.Password= passwordTextBox.Text;
            user.DOB = Convert.ToDateTime(DOBTextBox.Text);
            user.Gender = genderDropdownList.SelectedValue;

            int affetctedRow = userManager.SaveUser(user);
            if (affetctedRow < 0)
            {
                
            }
            else 
            {
                nameIDmessage.Attributes.Add("style", "display:block");
                nameMessageP.InnerHtml = "Registration Successfull. ";
            }
        }
    }
}