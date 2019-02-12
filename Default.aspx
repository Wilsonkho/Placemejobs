<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Using Forms Authentication</h3>
    <asp:Label ID="Welcome" runat="server" />
    <p><asp:Button ID="Button1" OnClick="Signout_Click" Text="Sign Out" runat="server" /></p>
</asp:Content>

