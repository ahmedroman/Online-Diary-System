<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentUI.aspx.cs" Inherits="OnlineDiarySystemWebWpp.UI.CommentUI" %>

<%@ Register Src="~/Controls/Header.ascx" TagPrefix="uc1" TagName="Header" %>



<form id="form1" runat="server">

    <uc1:Header runat="server" ID="Header" />
    <div class="commentArea">
        <div class="commentPostArea">
            <asp:hyperlink runat="server" id="nameLink"></asp:hyperlink>
            <asp:HyperLink cssClass="dateStyle" runat="server" id="timeLabel"></asp:HyperLink>
            <asp:label runat="server" id="postLabel"></asp:label>
            <asp:HyperLink cssClass="deleteStyle" Text="Delete Post" runat="server" id="deleteHyperLink" Visible="False"></asp:HyperLink>
        </div>
        <div class="comments">
            <asp:textbox runat="server" id="commentTextbox"></asp:textbox>
            <asp:Button runat="server" id="postCommentButton" Text="Comment" OnClick="postCommentButton_Click"></asp:Button>
            <asp:gridview runat="server" id="commentsGridView" autogeneratecolumns="false" 
                showheader="false" cssClass="commentTable">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%#String.Format("~/UI/UserProfileUI.aspx?UserId={0}", Eval("UserId")) %>' Text='<%#Eval("UserName") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("NewComment") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Time", "{0:MM:HH,dd MMM yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:gridview>
        </div>
    </div>
</form>
</body>
</html>
