<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DefaultPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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

        <br />
        <br />
        

        <!-- Script for showing modal !-->
        <script type="text/javascript">
            $(document).ready(function () {
                // Use jQuery to handle the button click event and show the modal
                $('#<%= btnOpenModal.ClientID %>').click(function () {
                $('#myModal').modal('show');
            });
        });
        </script>
</asp:Content>
