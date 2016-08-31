<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchUI.aspx.cs" Inherits="OnlineDiarySystemWebWpp.UI.SearchUI" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>


<form id="form1" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <div class="searchMain">
        <asp:GridView runat="server" ID="searchGridView"  showheader="false"
            AutoGenerateColumns="false" cssClass="searchTable">

            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img runat="server" src='<%#Eval("ProPic") %>'  id="proPicImage" />
                        <%--<img src="../Images/pollen.jpg" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" 
                            NavigateUrl='<%#String.Format("~/UI/UserProfileUI.aspx?UserId={0}", Eval("PersonId")) %>' Text='<%#Eval("PersonName") %>' >
                        </asp:HyperLink>
                        <asp:HyperLink runat="server" NavigateUrl='<%#Eval("NavigateUrl") %>' ID="followButton" Text='<%#Eval("FollowButtonText") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        
                        <asp:HyperLink runat="server" ID="Button1" NavigateUrl='<%#Eval("NavigateUrlFollower") %>'  Text='<%#Eval("FollowerCount")+"  Follower" %>'></asp:HyperLink>
                        <asp:HyperLink runat="server" ID="Button3" NavigateUrl='<%#Eval("NavigateUrlFollowing") %>' Text='<%#Eval("FollowingCount")+"  Following" %>'></asp:HyperLink>
                        
                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                         <asp:HyperLink runat="server" ID="Button2" Text='<%#"Age "+Eval("Age") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
