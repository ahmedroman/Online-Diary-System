<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUI.aspx.cs" Inherits="OnlineDiarySystemWebWpp.UI.RegisterUI" %>

<%@ Register Src="~/Controls/SiteMainHeader.ascx" TagPrefix="uc1" TagName="SiteMainHeader" %>


<uc1:SiteMainHeader runat="server" ID="SiteMainHeader" />
<form id="regForm" runat="server">
    <div class="registerForm inputForm">
        <div class="loginHeader">
            <p>Register</p>
        </div>
        <div class="registerMain inputTextbox">
            <div class="nameValidate" runat="server" id="nameIDmessage">
                <p runat="server" ID="nameMessageP">Name can't be blank</p>

            </div>
             <div class="emailValidate" runat="server" id="emailIDmessage">
                 <p runat="server" ID="emailMessageP">Email can't be blank</p>
             </div>
            <div class="usernameValidateReg" runat="server" id="usernameIDmessage">
                <p runat="server" ID="messageP">Username can't be blank</p>
            </div>
            <div class="passwordValidateReg"><p>Password can't be blank</p></div>
            <div class="confirmPasswordValidate"><p>Password don't match</p></div>
            <div class="DOBValidate"><p>Date can't be blank</p></div>
            <div class="genderValidate"><p>Gender can't be blank</p></div>

            <asp:textbox runat="server" id="nameTextBox" placeholder="Name"></asp:textbox>
            <asp:textbox runat="server" id="emailTextBox" placeholder="Email"></asp:textbox>
            <asp:textbox runat="server" id="usernameTextBox" placeholder="Username"></asp:textbox>
            <asp:textbox runat="server" TextMode="Password" id="passwordTextBox" placeholder="Password"></asp:textbox>
            <asp:textbox runat="server" TextMode="Password" id="confirmPasswordTextbox" placeholder="Confirm Passrod"></asp:textbox>
            <asp:textbox runat="server" id="DOBTextBox" placeholder="Date Of Birth"></asp:textbox>
            <asp:dropdownlist runat="server" placeholder="Gender" ID="genderDropdownList">
                <asp:ListItem Selected="True" Value="0" Text="Gender"></asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:dropdownlist>
            
            <%--<asp:radiobuttonlist runat="server" 
                id="genderradiobutton" repeatdirection="Horizontal">
                    <asp:ListItem Text="Male" Value="Male" />
                    <asp:ListItem Text="Femlale" Value="Femlale" />
                </asp:radiobuttonlist>--%>
        </div>
        <div class="loginFooter">
           
            <a href="LoginUI.aspx">Login</a>
            <asp:button runat="server" id="submitButton" text="Register" onclick="submitButton_Click"></asp:button>
        </div>
    </div>
</form>
<script src="../Scripts/jquery-1.12.4.min.js"></script>
<script src="../Scripts/jquery-ui-1.12.0.min.js"></script>
<script src="../Scripts/script.js"></script>
</body>
</html>
