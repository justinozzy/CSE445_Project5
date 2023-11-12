<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StockBuild.ascx.cs" Inherits="WebApplication1.StockBuild" %>

<div class="stock-build-control">

    <label for="limitBox">Enter number of stocks to list (limit: 1000):</label>
    <div class="input-group">
        <asp:TextBox ID="limitBox" runat="server" Width="85px"></asp:TextBox>
        <asp:Button ID="Enter" runat="server" Height="26px" OnClick="Enter_Click" Text="Enter" />
        &nbsp;(When Press the Enter button, stock build data is stored in an xml file called &quot;Member.xml&quot; in App_Data Folder)
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Click here to view xml file</asp:LinkButton>
    </div>

    <asp:TextBox ID="StockBuildBox" runat="server" Height="264px" TextMode="MultiLine" Width="100%"></asp:TextBox>
</div>

<p>
    Cookies are stored for the stock build, so the result you see above will be stored for about 2 hours. Try opening web app in a new tab to test it out.
</p>

<style>
    .stock-build-control {
        margin-bottom: 20px;
        background-color: #fff;
        padding: 15px;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    label {
        display: block;
        margin-bottom: 8px;
        color: #333;
    }

    .input-group {
        display: flex;
        align-items: center;
        margin-bottom: 15px;
    }

    .input-group input {
        margin-right: 10px;
    }

    #StockBuildBox {
        width: 100%;
        box-sizing: border-box;
        margin-top: 10px;
    }
</style>
