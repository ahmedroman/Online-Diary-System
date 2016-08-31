<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="OnlineDiarySystemWebWpp.Controls.Header" %>
<%@ Register Src="~/Controls/SiteMainHeader.ascx" TagPrefix="uc1" TagName="SiteMainHeader" %>

<uc1:SiteMainHeader runat="server" ID="SiteMainHeader" />
<header> 
    <p class="home">
        <asp:HyperLink runat="server" NavigateUrl="~/UI/Index.aspx" Text="Home"></asp:HyperLink></p>
    <p class="profile">
        <asp:HyperLink runat="server" ID="usernameLink"></asp:HyperLink></p>

    <p class="logout">
        <asp:Button runat="server" ID="logoutButton" Text="Logout" OnClick="logoutButton_Click"></asp:Button></p>
    <p class="searchTextbox">
        <asp:TextBox runat="server" ID="searchTextBox"></asp:TextBox>
        <asp:Button runat="server" ID="searchButton" Text="" OnClick="searchButton_Click"></asp:Button>
    </p>
</header>
