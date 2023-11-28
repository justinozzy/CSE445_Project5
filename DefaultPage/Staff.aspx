<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Staff.aspx.cs" Inherits="Yarramsetti_A6_Components._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Button runat="server" ID="staffLogoutButton" Text="Logout of Staff" OnClick="staffLogout_Click"></asp:Button>
        <br /><br />
    </div>
    <div>
        <h1><b>Staff</b></h1>

        <h3><b>Register</b></h3>

        <p>
            Enter login credentials so that you can register for the site.
            The file "Staff.xml" holds these credentials and it resides in the App_Data folder of this ASP project.
        </p>

        <asp:TextBox ID="Username" placeholder="Username" runat="server"></asp:TextBox>
        <asp:TextBox ID="Password" placeholder="Password" runat="server"></asp:TextBox>
        <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />

        <asp:Label ID="RegisterResults" runat="server" Text="Result shown here."></asp:Label>

        <h3><b>NewsFocus Service</b></h3>

        <p>
            Allows users to get URLs of news articles for a list of particular topics.
            Cookies are used to store the state of "Recently searched topics".
        </p>

        <p><b>Url:</b> <a href="http://webstrar51.fulton.asu.edu/page6/SOAPServicesLikhit.svc">http://webstrar51.fulton.asu.edu/page6/SOAPServicesLikhit.svc</a>
        </p>

        <p>Type comma separated topics to get news for:</p>

        <div>
            <asp:TextBox ID="TopicsInput" runat="server"></asp:TextBox>
            <asp:Button ID="NewsFocusButton" runat="server" Text="Send Request" OnClick="NewsFocusButton_Click" />
        </div>

        <div>
            <asp:Label ID="NewsFocusResults" CssClass="mt-5" runat="server" Text="Results shown here"></asp:Label>
        </div>

    </div>

</asp:Content>
