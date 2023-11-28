<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="DefaultPage.SignUp" %>

<%@ Register src="UserControls/SignUpCaptcha.ascx" tagname="SignUpCaptcha" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
    <div class="container">
        <a class="navbar-brand" runat="server" href="~/">CSE445 - Stock Broker Application</a>
        <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
            aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
    <ul class="navbar-nav flex-grow-1 align-items-center">
        <li class="nav-item"><a class="nav-link" runat="server" href="~/">Default</a></li>
        <li class="nav-item"><a class="nav-link" runat="server" href="~/Member">Member</a></li>
        <li class="nav-item"><a class="nav-link" runat="server" href="~/Staff">Staff</a></li>
        <li class="nav-item"><a class="nav-link" runat="server" href="http://webstrar51.fulton.asu.edu/">Directory Table</a></li>
        <li class="nav-item align-items-center" style="margin-left:100px;"><asp:Label runat="server" class="nav-link" ID="StatusLabel" ForeColor="White"></asp:Label></li>
        <li class="nav-item align-items-center" style="margin-top:30px;">
    </ul>
    </div>
        </div>
        </nav>
    <form id="form1" runat="server">
        <div>
        </div>
        <uc1:SignUpCaptcha ID="SignUpCaptcha1" runat="server" />
    </form>
    <asp:PlaceHolder runat="server">
    <%: Scripts.Render("~/Scripts/bootstrap.js") %>
    </asp:PlaceHolder>
</body>
</html>
