<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editProfileUI.aspx.cs" Inherits="OnlineDiarySystemWebWpp.UI.editProfileUI" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>



<form id="regForm" runat="server">
    <uc1:Header runat="server" ID="Header" />
    <div class="editForm inputEditForm">
        <div class="editHeader">
            <img src="../Images/pollen.jpg" />
        </div>
        <div class="editMain inputEditTextbox">
            <div class="nameValidate" runat="server" id="nameIDmessage">
                <p runat="server" id="nameMessageP">Name can't be blank</p>

            </div>
            <div class="emailValidate" runat="server" id="emailIDmessage">
                <p runat="server" id="emailMessageP">Email can't be blank</p>
            </div>
            <div class="usernameValidateReg" runat="server" id="usernameIDmessage">
                <p runat="server" id="messageP">Username can't be blank</p>
            </div>
            <div class="passwordValidateReg">
                <p>Password can't be blank</p>
            </div>
            <div class="confirmPasswordValidate">
                <p>Password don't match</p>
            </div>
            <div class="DOBValidate">
                <p>Date can't be blank</p>
            </div>
            <div class="genderValidate">
                <p>Gender can't be blank</p>
            </div>

            <asp:textbox runat="server" id="nameTextBox" placeholder="Name"></asp:textbox>
            <asp:textbox runat="server" id="emailTextBox" placeholder="Email"></asp:textbox>
            <asp:textbox runat="server" id="usernameTextBox" placeholder="Username"></asp:textbox>
            <asp:textbox runat="server" textmode="Password" id="passwordTextBox" placeholder="Password"></asp:textbox>
            <asp:textbox runat="server" textmode="Password" id="confirmPasswordTextbox" placeholder="Confirm Passrod"></asp:textbox>
            <asp:textbox runat="server" id="DOBTextBox" placeholder="Date Of Birth"></asp:textbox>
            <asp:dropdownlist runat="server" placeholder="Gender" id="genderDropdownList">
                <asp:ListItem Selected="True" Value="0" Text="Gender"></asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:dropdownlist>

        </div>
        <div class="editFooter">
            <asp:button runat="server" id="submitButton" text="Edit" OnClick="submitButton_Click" ></asp:button>
        </div>
    </div>
</form>
<script src="../Scripts/jquery-1.12.4.min.js"></script>
<script src="../Scripts/jquery-ui-1.12.0.min.js"></script>
<script src="../Scripts/script.js"></script>
</body>
</html>