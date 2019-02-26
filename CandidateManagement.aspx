﻿<%@ Page Title="Candidate Management" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidateManagement.aspx.cs" Inherits="CandidateManagement" %>
<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">


</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MatchTable').DataTable();
        });
    </script>
    <table id=" MatchTable">
        <thead>
            <tr>
                <th>Name</th>
                <th>Profession</th>
                <th>Region</th>
                <th>Phone</th>
                <th>Email</th>
                <th>Cover</th>
                <th>Resume</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Mickey Mouse</td>
                <td>Accountant</td>
                <td>Ghatkopar</td>
                <td>7809514242</td>
                <td>mickeyhere@gmail.com</td>
                <td>Cover Letter</td>
                <td>Resume</td>
            </tr>
        </tbody>

    </table>
    <asp:Table ID="Results" runat="server" border="1">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Profession</asp:TableHeaderCell>
            <asp:TableHeaderCell>Region</asp:TableHeaderCell>
            <asp:TableHeaderCell>Phone</asp:TableHeaderCell>
            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
            <asp:TableHeaderCell>Cover Letter</asp:TableHeaderCell>
            <asp:TableHeaderCell>Resume</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

</asp:Content>

