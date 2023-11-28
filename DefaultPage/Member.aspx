<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register src="UserControls/SignUpCaptcha.ascx" tagname="SignUpCaptcha" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="stock-section">
            <h2>
                <h2>Stock Build Service</h2>
            <p>Using the Polygon.io API, get 500 random stock tickers from NASDAQ</p>
            <p>This is a web user control that creates a stock build. The ascx file for this can be found in the "UserControls" folder.
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Click here to view the user control</asp:LinkButton>
            </p>
            <div class="stock-build">
                <build:stockbuild ID="StockBuild" runat="server" />
            </div>
        </div>

        <div class="separator"></div> <!-- Add a separator between the sections -->

        <div class="quote-section">
            <h2>Stock Quote</h2>
            <p>This is a web user control that shows a stock quote. The ascx file for this can be found in the "UserControls" folder.
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Click here to view the User Control</asp:LinkButton>
            </p>
            <div class="stock-quote">
                <quote:StockQuote ID="StockQuote1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

