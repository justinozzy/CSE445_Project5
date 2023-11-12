﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DefaultPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <p>
                <b>Login Button</b> - Asks a user for their username and password and confirms their login information through an XML file.
                The current user logged in will be saved in a cookie and the way to test this is to check the save login information box, close your browser, and reopen this page.
                You will see that you're still currently logged in as member until you logout.
                (Make sure you're not in incognito and have cookies enabled)
                <br />
                <br />
                This login button is the same one at the top of the page and triggers a global variable in global.asax that we will use to update our pages when they're logged in.
                <br />
                <b>The current login status is:</b> <asp:Label runat="server" ID="loginStatus" />
                <br />
                <br />
                Once you login a global 
                Passwords are hashed using by a DLL function that converts it to base64. You can test the DLL functionality below in the corresponding box and button.
                <br />
                <br />
                Login Credentials - <b>Username: </b> member   <b>Password: </b> password

            </p>
        </div>
        <asp:Label runat="server" ID="StatusLabel" Text=""/>
        <br />
        <br />
        <!-- Login and Logout buttons !-->
        <asp:Button ID="btnOpenModal" runat="server" Text="Login" CssClass="btn btn-primary" OnClientClick="return false;" />
        <asp:Button ID="logOutButton" runat="server" Text="Logout" CssClass="btn btn-primary" OnClick="Logout_Click" />

        <!-- Modal login popup !-->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="ModalLogin" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ModalLoginTitle">Enter Login Info</h5>
                        <asp:Button text="X" runat="server" type="button" CssClass="btn btn-secondary close" data-bs-dismiss="modal" />
                    </div>
                    <div class="modal-body mx-auto">
                        <asp:TextBox runat="server" ID="loginUsername" ToolTip="Enter username" class="mb-2" placeholder="Enter Username" />
                        <br />
                        <asp:TextBox runat="server" ID="loginPassword" placeholder="Enter Password" class="mb-2" TextMode="Password" />
                        <br />
                        <asp:CheckBox ID="saveInfoBox" runat="server" class="mb-2"/> <asp:Label runat="server" Text="Save Login Information" />
                    </div>
                    <div class="modal-footer">
                        <asp:Button Text="Login" ID="LoginButton" type="button" runat="server" class="btn btn-secondary close mx-auto" data-bs-dismiss="modal" OnClick="Login_Click" />
                    </div>
                </div>
            </div>
        </div>

    <!-- Script for showing modal !-->
    <script type="text/javascript">
        $(document).ready(function () {
            // Use jQuery to handle the button click event and show the modal
            $('#<%= btnOpenModal.ClientID %>').click(function () {
                $('#myModal').modal('show');
            });
        });
    </script>

        <br />
        <br />

        <div>
            <b>Test Hash</b>
            <br />
            <asp:Label Text="Enter your text" runat="server" />
            <asp:TextBox runat="server" ID="hashBox"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" ID="hashButton" Text="Encode text" OnClick="DLL_Click"/>
            <br />
            <asp:Label runat="server" ID="hashLabel" />
        </div>
         <br />
         <br />

     <div>
                <b>GPTSupportService</b>
                <br />
                Takes in a users message and puts it through a stock broker support prompt (https://platform.openai.com/docs/introduction). Returns a string response.
                <br />
                <br />
                <b>Url:</b> <asp:HyperLink ID="GPTSupportURL" runat="server">http://webstrar51.fulton.asu.edu/page3/api/GPTSupport</asp:HyperLink>
                <br />
                <br />
            </div>

            <div>
                <asp:TextBox ID="UserMessageBox" placeholder="Enter your prompt/question" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="GPTButton" runat="server" Text="Send Prompt" OnClick="GPTButton_Click" CssClass="item_spacing"/>
                <br />
                <br />
                <asp:TextBox id="GPTResponseArea" TextMode="MultiLine" Rows="4" Columns="50" runat="server"></asp:TextBox>
            </div>

</asp:Content>
