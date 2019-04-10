<%@ Page Title="View Job Postings" Language="C#" AutoEventWireup="true" CodeFile="ViewJobPosting.aspx.cs" Inherits="JobPostingStatus" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-header">
        <br />
        <h1>View Job Postings</h1>
        <hr />
    </div>
    <asp:Table ID="JobPostingsTable" runat="server" class="table table-striped table-bordered" />
 
</asp:Content>