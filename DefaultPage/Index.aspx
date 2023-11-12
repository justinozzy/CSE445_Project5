<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="WebApplication1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET Table Example</title>
    <style>
        .bordered-table {
            border-collapse: collapse;
            width: 100%;
        }

        .bordered-table th, .bordered-table td {
            border: 1px solid black;
            padding: 8px;
            text-align: left;
        }
        .custom-link {
            color: blue;
            font-weight: bold;
            font-size: 20px; 
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Abhisekhar Bharadwaj Gandavarapu - Project 5, Assignment 6</h2>
            <h3>Application and Components Summary Table</h3>

             <asp:Table ID="ComponentTable" runat="server" CssClass="bordered-table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>
                        Page and Component
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        Component Description
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        Actual Resources and Methods Used
                    </asp:TableHeaderCell>
                   
                </asp:TableHeaderRow>

                <asp:TableRow>
                    <asp:TableCell>User controls</asp:TableCell>
                    <asp:TableCell>Developed User controls for Stock build and Stock quote</asp:TableCell>
                    <asp:TableCell>
                        C# Code behind GUI. Linked to the Member page
                    </asp:TableCell>
                    
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>XML file storage</asp:TableCell>
                    <asp:TableCell>Stores Stock Build data by taking an input for the limit of stocks to show in the build, compiles the data in an XML file, and stores it in the App_Data folder</asp:TableCell>
                    <asp:TableCell>Linked to Member Page and stores User's stock build data</asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Cookies</asp:TableCell>
                    <asp:TableCell>Saves the user's stock build and stock quote displayed on the web app</asp:TableCell>
                    <asp:TableCell>
                        GUI design and C# code behind GUI using HTTP cookies library. It is linked to the Member page such that stock build data and stock quote data are saved.
                    </asp:TableCell>
                    
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="custom-link">Click here to navigate to Member.Aspx and test out components</asp:LinkButton>
            <br />
        </div>
    </form>
</body>
</html>

