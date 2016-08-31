using OnlineDiarySystemWebWpp.BLL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiarySystemWebWpp.UI
{
    public partial class Index : System.Web.UI.Page
    {
        ProfilePicManager profilePicManager = new ProfilePicManager();
        UserManager userManager = new UserManager();
        PostManager postManager = new PostManager();
        FollowManager followManager = new FollowManager();
        User loggedInUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            checkLoggedin();

            loggedInUser = (User)Session["User"];
            LoadProPic(loggedInUser.Id);
            editProfileLink.NavigateUrl = String.Format("~/UI/editProfileUI.aspx?UserId={0}",
                        loggedInUser.Id);
            nameLabel.NavigateUrl = String.Format("~/UI/UserProfileUI.aspx?UserId={0}",
                        loggedInUser.Id);
            LoadUser(userManager.GetUserById(loggedInUser.Id));

            int followingCount = followManager.GetFollowerByPersonId(loggedInUser.Id).Count();
            //folloew count
            int followerCount = followManager.GetFollowerCountOfPerson(loggedInUser.Id).Count();
            followerButton.Text = followerCount + " Follower";
            followerButton.NavigateUrl = String.Format("~/UI/SearchUI.aspx?FollowerUserId={0}", loggedInUser.Id);
            followingButton.Text = followingCount + " Following";
            followingButton.NavigateUrl = String.Format("~/UI/SearchUI.aspx?FollowingUserId={0}", loggedInUser.Id);
                    

            LoadPostGridView();
        }

        
        private void LoadUser(User user)
        {
            nameLabel.Text = user.Name;
            usernameLabel.Text = user.Username;
            emailLabel.Text = user.Email;
            DOBLabel.Text = user.DOB.ToString();
            genderLabel.Text = user.Gender;
        }

        private void LoadPostGridView()
        {
            showPostGridView.DataSource = postManager.GetAllPost();
            showPostGridView.DataBind();
        }
        private void checkLoggedin()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/UI/LoginUI.aspx");
            }
        }

        protected void postButton_Click1(object sender, EventArgs e)
        {
            Post post = new Post();
            post.NewPost = postTextBox.Text;
            post.Time = DateTime.Now;
            if (visibilityCheckbox.Checked)
            {
                post.Visibility = 0;
            }
            else {
                post.Visibility = 1;
            }
            
            post.UserId = loggedInUser.Id;
            post.UserName = loggedInUser.Name;
            int affectedRow = postManager.SavePost(post);
            postTextBox.Text = "";
            LoadPostGridView();
        }

        private void LoadProPic(int userId)
        {
            User profileUser = userManager.GetUserById(userId);
            if (profileUser.ProPicId != 0)
            {

                ProfilePic propic = profilePicManager.GetProPicById(profileUser.ProPicId);
                var base64 = Convert.ToBase64String(propic.ImageData);
                string imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                proPicImage.Attributes.Add("src", imgSrc);
                proPicImage.Attributes.Add("height", "225px");
                proPicImage.Attributes.Add("width", "100%");
            }
            else
            {
                proPicImage.Attributes.Add("src", "../Images/pollen.jpg");
                proPicImage.Attributes.Add("width", "100%");
                proPicImage.Attributes.Add("height", "225px");
            }
        }
        protected void uploadButton_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = profilePicImg.PostedFile;

            ProfilePic profilePic = new ProfilePic();
            profilePic.Name = Path.GetFileName(postedFile.FileName);
            profilePic.Size = postedFile.ContentLength;
            Stream stream = postedFile.InputStream;
            BinaryReader br = new BinaryReader(stream);
            profilePic.ImageData = br.ReadBytes((int)stream.Length);
            profilePic.UserId = loggedInUser.Id;

            int proPicId = profilePicManager.SaveProfilePic(profilePic);

            User user = new User();
            user.ProPicId = proPicId;
            user.Id = loggedInUser.Id;
            userManager.UpdateUserWithPic(user);
            LoadProPic(user.Id);

        }

        

        

        


    }
}