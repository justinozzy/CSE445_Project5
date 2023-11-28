<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignUpCaptcha.ascx.cs" Inherits="DefaultPage.UserControls.SignUpCaptcha" %>

  <%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<div style="font-family: Arial">
    <h3>User Registration</h3>

    <table style="border: 1px solid black">
        <tr>
            <td>
                <b>Name </b>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="230px">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <b>Email </b>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="230px">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <b>Password </b>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="230px"
                                TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <recaptcha:RecaptchaControl ID="recaptcha" runat="server"
                    PublicKey="6Lee7h4pAAAAAIKAFZoJx9Kwlyd4W8TSRFyMywgC"
                    PrivateKey="6Lee7h4pAAAAANyO8FikXM5rMU1j72Wxs-ZCLSZf" />
         
                 <script src="https://www.google.com/recaptcha/api.js" async defer></script>
  


        <div class="g-recaptcha" data-sitekey="6Lee7h4pAAAAAIKAFZoJx9Kwlyd4W8TSRFyMywgC"></div>
        <br />
       <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClientClick="return validateCaptcha();" OnClick="btnSubmit_Click" />

                <script>
    function validateCaptcha() {
        // Get reCAPTCHA response token
        var recaptchaResponse = grecaptcha.getResponse();

        // Perform client-side verification
        if (recaptchaResponse.trim() === "") {
            alert("reCAPTCHA verification failed. Please try again.");
            return false;
        }

        // If reCAPTCHA is valid, proceed with server-side validation
        return true;
    }
                </script>
            </td>
        </tr>
       
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>