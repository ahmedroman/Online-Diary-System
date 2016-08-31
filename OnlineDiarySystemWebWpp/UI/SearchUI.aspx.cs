using OnlineDiarySystemWebWpp.BLL;
using OnlineDiarySystemWebWpp.Models;
using OnlineDiarySystemWebWpp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineDiarySystemWebWpp.UI
{
    public partial class SearchUI : System.Web.UI.Page
    {
        ProfilePicManager profilePicManager = new ProfilePicManager();
        FollowManager followManager = new FollowManager();
        UserManager userManager = new UserManager();
        User loggedInUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            checkLoggedin();

            loggedInUser = (User)Session["User"];

            if (!IsPostBack) 
            {
                if (Request.QueryString["search"] != null)
                {
                    string name = Request.QueryString["search"];
                    LoadGridview(userManager.GetUserByName(name));
                }
                else if (Request.QueryString["FollowerUserId"] != null)
                {
                    int personId = Convert.ToInt32(Request.QueryString["FollowerUserId"]);
                    List<Follow> followingList = followManager.GetFollowerCountOfPerson(personId);
                    List<User> userList = new List<User>();
                    foreach(Follow follow in followingList)
                    {
                        userList.Add(FindUser(follow.FollowerId));
                    }
                    LoadGridview(userList);
                }
                else if (Request.QueryString["FollowingUserId"] != null)
                {
                    int personId = Convert.ToInt32(Request.QueryString["FollowingUserId"]);
                    List<Follow> followingList = followManager.GetFollowerByPersonId(personId);
                    List<User> userList = new List<User>();
                    foreach (Follow follow in followingList)
                    {
                        userList.Add(FindUser(follow.PersonId));
                    }
                    LoadGridview(userList);
                }
            }
        }

        private User FindUser(int userId)
        {
            return userManager.GetUserById(userId);
        }

        private List<Search> GetSearchInfo(List<User> userList)
        {
            List<Search> searchList = new List<Search>();
            
            foreach(User user in userList)
            {
                string imgSrc;
                if (user.ProPicId != 0)
                {
                    byte[] imgData = profilePicManager.GetProPicById(user.ProPicId).ImageData;
                    var base64 = Convert.ToBase64String(imgData);
                    imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                }
                else {
                    imgSrc = String.Format("../Images/pollen.jpg");
                }
                Search search = new Search();
                search.PersonId = user.Id;
                search.PersonName = user.Name;
                search.ProPic = imgSrc;
                search.FollowingCount = followManager.GetFollowerByPersonId(user.Id).Count();
                //folloew count
                search.FollowerCount = followManager.GetFollowerCountOfPerson(user.Id).Count();
                
                search.Age = (int)(DateTime.Now - user.DOB).TotalDays;
                if(user.Id == loggedInUser.Id)
                {
                    search.FollowButtonText = "Edit Profile";
                    search.NavigateUrl = String.Format("~/UI/editProfileUI.aspx?UserId={0}", loggedInUser.Id);
                }
                else if (followManager.CheckFollower(user.Id, loggedInUser.Id) != null)
                {
                    search.FollowButtonText = "Following";

                }
                else { 
                    search.FollowButtonText = "Follow";
                    search.NavigateUrl = String.Format("~/UI/FollowUI.aspx?FollowerId={0}&&FollowerName={1}&&PersonId={2}",
                        loggedInUser.Id, loggedInUser.Name, user.Id);
                }
                search.NavigateUrlFollower = String.Format("~/UI/SearchUI.aspx?FollowerUserId={0}", user.Id);
                search.NavigateUrlFollowing = String.Format("~/UI/SearchUI.aspx?FollowingUserId={0}", user.Id);
                
                searchList.Add(search);
            }
            return searchList;
            
        }
        private void LoadGridview(List<User> userList)
        {
            searchGridView.DataSource = GetSearchInfo(userList);
            searchGridView.DataBind();
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