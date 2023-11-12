<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StockQuote.ascx.cs" Inherits="WebApplication1.User_Controls.StockQuote" %>

<div class="stock-quote-control">
    
    <div class="stock-quote-inputs">
        <label for="symbolBox">Stock Symbol:</label>
        <asp:TextBox ID="symbolBox" runat="server"></asp:TextBox>
        <asp:Button ID="SymbolBtn" runat="server" OnClick="SymbolBtn_Click" Text="Enter" />
    </div>

    <div class="stock-quote-result">
        <p>Price: $<asp:Label ID="price" runat="server" Text=" "></asp:Label></p>
    </div>

    <p class="stock-quote-message">
        Cookies are stored for the stock quote, so the result you see above will be stored for about 2 hours. Try opening web app in a new tab to test it out.
    </p>
</div>

<style>
    .stock-quote-control {
        margin: 0 auto;
        padding: 15px;
        background-color: #fff;
        border: 1px solid #ddd;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .stock-quote-inputs {
        margin-bottom: 10px;
    }

    label {
        display: block;
        margin-bottom: 5px;
    }

    .stock-quote-result {
        margin-bottom: 10px;
    }

    .stock-quote-message {
        color: #555;
    }
</style>
