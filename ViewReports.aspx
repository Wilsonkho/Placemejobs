<%@ Page Title="View Reports" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewReports.aspx.cs" Inherits="ViewReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>View Reports</h1>
    <table class="table-bordered">
        <thead>
            <tr>
                <td>Status</td>
                <td>Action</td>
            </tr>
        </thead>
        <tr>
            <td>Interviewing</td>
            <td><asp:Button runat="server" ID="Button1" OnClientClick="window.open('ReportDisplay.aspx?status=Interviewing')" Text="View" /></td>
        </tr>
        <tr>
            <td>Selected</td>
            <td><asp:Button runat="server" ID="Button2" OnClientClick="window.open('ReportDisplay.aspx?status=Selected')" Text="View" /></td>
        </tr>
        <tr>
            <td>Rejected</td>
            <td><asp:Button runat="server" ID="Button3" OnClientClick="window.open('ReportDisplay.aspx?status=Rejected')" Text="View" /></td>
        </tr>
        <tr>
            <td>Joined</td>
            <td><asp:Button runat="server" ID="Button4" OnClientClick="window.open('ReportDisplay.aspx?status=Joined')" Text="View" /></td>
        </tr>
        <tr>
            <td>On-Hold</td>
            <td><asp:Button runat="server" ID="Button5" OnClientClick="window.open('ReportDisplay.aspx?status=On-Hold')" Text="View" /></td>
        </tr>
    </table>
</asp:Content>

