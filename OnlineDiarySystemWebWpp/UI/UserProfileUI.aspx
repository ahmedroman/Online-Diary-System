<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfileUI.aspx.cs" Inherits="OnlineDiarySystemWebWpp.UI.UserProfileUI" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<%@ Register Src="~/Controls/SiteMainHeader.ascx" TagPrefix="uc1" TagName="SiteMainHeader" %>


<form id="form1" runat="server">

    <uc1:Header runat="server" ID="Header" />


    <div class="mainProfilePage">
        <div class="leftProfileArea">
            <div class="proPic">
                <img runat="server"   id="proPicImage" />
                <div class="afterImgDiv"  runat="server" id="propicDiv" visible="false">
                    <input type="file" runat="server" id="profilePicImg" name="profilePic" />
                    <asp:button runat="server" text="Upload" Id="uploadButton" OnClick="uploadButton_Click" ></asp:button>
                </div>
            </div>
            <asp:hyperlink runat="server" cssclass="fullButton" id="nameLabel"></asp:hyperlink>
            <asp:hyperlink runat="server" cssclass="halfButton" id="followerButton"></asp:hyperlink>
            <asp:hyperlink runat="server" cssclass="halfButton" id="followingButton"></asp:hyperlink>

            <p>
                <span>Username</span>
                <asp:label runat="server" id="usernameLabel"></asp:label>
            </p>
            <p>
                <span>Email</span>
                <asp:label runat="server" id="emailLabel"></asp:label>
            </p>
            <p>
                <span>Gender</span>
                <asp:label runat="server" id="genderLabel"></asp:label>
            </p>
            <p>
                <span>Date Of Birth</span>
                <asp:label runat="server" id="DOBLabel"></asp:label>
            </p>

            <asp:hyperlink runat="server" id="editProfileLink" cssclass="fullButton edit-profile-button"></asp:hyperlink>
        </div>
        <div class="mainProfilePosstArea">
            <div class="profilePostArea">
                <asp:textbox id="postTextBox" runat="server" textmode="MultiLine"></asp:textbox>
                <div class="visibilityDiv">
                    <asp:checkbox runat="server" id="visibilityCheckbox" value="1"></asp:checkbox>
                    <label for="visibilityCheckbox">
                        <label>
                </div>
                <asp:button runat="server" id="postButton" text="Post" onclick="postButton_Click"></asp:button>

            </div>
            <div class="profile-show-post">

                <asp:gridview runat="server" id="showPostGridView" autogeneratecolumns="false"
                    showheader="false" cssclass="postGrid">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%#String.Format("~/UI/UserProfileUI.aspx?UserId={0}", Eval("UserId")) %>' Text='<%#Eval("UserName") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("NewPost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("Time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%#String.Format("~/UI/CommentUI.aspx?postId={0}", Eval("Id") ) %>' Text="Comment"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:gridview>


            </div>
        </div>

    </div>


</form>
</body>
</html>
