﻿ <%@ Page Title="Candidate Management" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidateManagement.aspx.cs" Inherits="CandidateManagement" %>
<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">


</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="Content/JQueryDataTable.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
    
    <style>  
        .showHide {  
            cursor: pointer;  
        }  
    </style>  
    <div class="page-header">
        <br />
        <h1><asp:Label runat="server" ID="HeaderLabel" /></h1>
        <small><asp:Label runat="server" ID="SmallLabel" /></small>
        <hr />
    </div>
    
    <asp:Table ID="QualifiedCandidate" runat="server" class="table table-striped table-bordered"/>
    <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="BackButton_Click" Class="btn btn-dark"/><br />
    
</asp:Content>

