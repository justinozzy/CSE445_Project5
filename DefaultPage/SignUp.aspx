<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="DefaultPage.SignUp" %>

<%@ Register src="UserControls/SignUpCaptcha.ascx" tagname="SignUpCaptcha" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <uc1:SignUpCaptcha ID="SignUpCaptcha1" runat="server" />
    </form>
</body>
</html>
