<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewReports.aspx.cs" Inherits="ViewReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Button runat="server" ID="PopupButton" OnClientClick="window.open('ReportDisplay.aspx')" Text="View Report" />
</asp:Content>

