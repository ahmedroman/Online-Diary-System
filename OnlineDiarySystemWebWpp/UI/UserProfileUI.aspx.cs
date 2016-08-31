using OnlineDiarySystemWebWpp.BLL;
using OnlineDiarySystemWebWpp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineDiarySystemWebWpp.UI
{
    public partial class UserProfileUI : System.Web.UI.Page
    {
        ProfilePicManager profilePicManager = new ProfilePicManager();
        PostManager postManager = new PostManager();
        UserManager userManager = new UserManager();
        FollowManager followManager = new FollowManager();
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
                    LoadProPic(userId);
                    User currentUserProfile = userManager.GetUserById(userId);
                    LoadUser(currentUserProfile);
                    nameLabel.NavigateUrl = String.Format("~/UI/UserProfileUI.aspx?UserId={0}",
                        userId);
                    int followingCount = followManager.GetFollowerByPersonId(userId).Count();
                    //folloew count
                    int followerCount = followManager.GetFollowerCountOfPerson(userId).Count();
                    followerButton.Text = followerCount + " Follower";
                    followerButton.NavigateUrl = String.Format("~/UI/SearchUI.aspx?FollowerUserId={0}", userId);
                    followingButton.Text = followingCount + " Following";
                    followingButton.NavigateUrl = String.Format("~/UI/SearchUI.aspx?FollowingUserId={0}", userId);

                    if (userId == loggedInUser.Id)
                    {
                        LoadAllPostGridView(userId);
                    }
                    else {
                        LoadPostGridView(userId, 1);
                    }

                    if (userId == loggedInUser.Id)
                    {
                        propicDiv.Visible = true;
                        editProfileLink.Text = "Edit Profile";
                        editProfileLink.NavigateUrl = String.Format("~/UI/editProfileUI.aspx?UserId={0}",
                        userId);
                    }
                    else if (FoundFollower(userId))
                    {
                        editProfileLink.Text = "UnFollow";
                        editProfileLink.NavigateUrl = String.Format("~/UI/FollowUI.aspx?UnFollow={0}&&PersonId={1}",
                            userId, loggedInUser.Id);
                    }
                    else
                    {
                        editProfileLink.Text = "Follow";
                        editProfileLink.NavigateUrl = String.Format("~/UI/FollowUI.aspx?FollowerId={0}&&FollowerName={1}&&PersonId={2}",
                        loggedInUser.Id, loggedInUser.Name, currentUserProfile.Id);
                    }
                }
                else
                {
                    Response.Redirect("~/UI/Index.aspx");
                }
            }
        }
        private void LoadProPic(int userId)
        {
            User profileUser = userManager.GetUserById(userId);
            if (profileUser.ProPicId != 0)
            {

                ProfilePic propic = profilePicManager.GetProPicById(profileUser.ProPicId);
                var base64 = Convert.ToBase64String(propic.ImageData);
                var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
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
        private bool FoundFollower(int currentProfile)
        {
            List<Follow> followerList = followManager.GetFollowerByPersonId(loggedInUser.Id);
            foreach (Follow follower in followerList)
            {
                if (currentProfile == follower.PersonId)
                {
                    return true;
                }
            }
            return false;
        }
        private void LoadUser(User user)
        {
            nameLabel.Text = user.Name;
            usernameLabel.Text = user.Username;
            emailLabel.Text = user.Email;
            DOBLabel.Text = user.DOB.ToString();
            genderLabel.Text = user.Gender;
        }
        private void LoadPostGridView(int userId, int visibility)
        {
            showPostGridView.DataSource = postManager.GetPostByUserId(userId, visibility);
            showPostGridView.DataBind();
        }
        private void LoadAllPostGridView(int userId)
        {
            showPostGridView.DataSource = postManager.GetAllPostByUserId(userId);
            showPostGridView.DataBind();
        }
        private void checkLoggedin()
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/UI/LoginUI.aspx");
            }
        }
        protected void postButton_Click(object sender, EventArgs e)
        {
            Post post = new Post();
            post.NewPost = postTextBox.Text;
            post.Time = DateTime.Now;
            if (visibilityCheckbox.Checked)
            {
                post.Visibility = 0;
            }
            else
            {
                post.Visibility = 1;
            }
            post.UserId = loggedInUser.Id;
            post.UserName = loggedInUser.Name;
            int affectedRow = postManager.SavePost(post);
            postTextBox.Text = "";
            if (Convert.ToInt32(Request.QueryString["UserId"]) == loggedInUser.Id)
            {
                LoadAllPostGridView(loggedInUser.Id);
            }
            else {
                LoadPostGridView(Convert.ToInt32(Request.QueryString["UserId"]), 1);
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