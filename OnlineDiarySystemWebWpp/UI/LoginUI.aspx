<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="OnlineDiarySystemWebWpp.UI.LoginUI" %>

<%@ Register Src="~/Controls/SiteMainHeader.ascx" TagPrefix="uc1" TagName="SiteMainHeader" %>


<uc1:SiteMainHeader runat="server" ID="SiteMainHeader" />

<form id="loginForm" runat="server">
    <div class="loginForm inputForm">
        <div class="loginHeader">Login</div>
        <div class="loginMain inputTextbox">
            <asp:textbox runat="server" id="usernameTextBox" placeholder="Username"></asp:textbox>
            
            <asp:textbox runat="server" id="passwordTextBox" TextMode="Password" placeholder="Password"></asp:textbox>
            
            <div class="usernameValidate" runat="server" id="usernameIDmessage"><p runat="server" ID="messageP">Username can't be blank</p></div>
            <div class="passwordValidate"><p>Password can't be blank</p></div>
              
        </div>
        <div class="loginFooter">
            
            <%--<asp:label runat="server" id="messageLabel"></asp:label>--%>
            <a href="RegisterUI.aspx">Register</a>
            <asp:button runat="server" id="submitButton" text="Login" onclick="submitButton_Click"></asp:button>

        </div>
    </div>

</form>
<script src="../Scripts/jquery-1.12.4.min.js"></script>
<script src="../Scripts/jquery-ui-1.12.0.min.js"></script>
<script src="../Scripts/script.js"></script>

</body>
</html>
