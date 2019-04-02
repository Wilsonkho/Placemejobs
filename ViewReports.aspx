<%@ Page Title="View Reports" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewReports.aspx.cs" Inherits="ViewReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <br /><br />
        <div class="header-blue">
            <h1 class="text-center">View Reports</h1>
            </div>
         <br />
    <asp:table runat="server" ID="ViewReportTable" class=" table-active" HorizontalAlign="Center">
<%--        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="label-text"><h4 class="text-center">Status</h4></asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="label-text"><h4 class="text-center">Action</h4></asp:TableHeaderCell>
        </asp:TableHeaderRow>    --%>    
        <asp:TableRow>
            <asp:TableCell CssClass="label-text"><h5>Interviewing</h5></asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="Button1" CssClass="btn btn-dark" OnClientClick="window.open('ReportDisplay.aspx?status=Interviewing')" Text="View" />
            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
            <asp:TableCell CssClass="label-text"><h5>Selected</h5></asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="Button2" CssClass="btn btn-dark" OnClientClick="window.open('ReportDisplay.aspx?status=Selected')" Text="View" />
            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
            <asp:TableCell CssClass="label-text"><h5>Rejected</h5></asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="Button3" CssClass="btn btn-dark" OnClientClick="window.open('ReportDisplay.aspx?status=Rejected')" Text="View" />
            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
            <asp:TableCell CssClass="label-text"><h5>Joined</h5></asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="Button4" CssClass="btn btn-dark" OnClientClick="window.open('ReportDisplay.aspx?status=Joined')" Text="View" />
            </asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow>
            <asp:TableCell CssClass="label-text"><h5>On Hold</h5></asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="Button5" CssClass="btn btn-dark" OnClientClick="window.open('ReportDisplay.aspx?status=On-Hold')" Text="View" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:table>
</asp:Content>

