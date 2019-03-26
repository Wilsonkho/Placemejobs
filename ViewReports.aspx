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
            <td><asp:Button runat="server" ID="Button1" OnClientClick="window.open('ReportDisplay.aspx?status=Interviewing')" Text="View Report" /></td>
        </tr>
    </table>
</asp:Content>

