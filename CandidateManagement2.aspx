<%@ Page Title="Candidate Management" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidateManagement2.aspx.cs" Inherits="CandidateManagement2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-header">
        <br />
        <h1>View Candidates by Job Matches</h1>
        <hr />
    </div>
    <asp:Table ID="JobPostingsTable" runat="server" class="table table-striped table-bordered table-white" />
 
</asp:Content>

