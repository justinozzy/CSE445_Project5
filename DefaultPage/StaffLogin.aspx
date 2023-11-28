<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="DefaultPage.StaffLogin" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <div>
        <asp:Label runat="server">Sign In to Staff Account</asp:Label>
        <br />
        <asp:TextBox runat="server" ID="UsernameBox" placeholder="Enter username"></asp:TextBox>
        <br />
        <asp:TextBox runat="server" ID="PasswordBox" placeholder="Enter password" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="staffLoginButton" OnClick="staffLogin_Click" Text="Login as Staff"/>
        <br /><br />
        <asp:Label runat="server" ID="errResponse"></asp:Label>
    </div>
    <asp:PlaceHolder runat="server">
    <%: Scripts.Render("~/Scripts/bootstrap.js") %>
    </asp:PlaceHolder>
    </asp:Content>