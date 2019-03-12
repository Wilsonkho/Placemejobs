
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCandidates.aspx.cs" Inherits="ViewCandidates" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
    
    <style>  
        .showHide {  
            cursor: pointer;  
        }  
    </style>  
<script type="text/javascript">  
     $(document).ready(function () {  
         $.ajax({  
             type: "POST",  
             dataType: "json",  
             url: "WebService.asmx/AllCandidates",  
             success: function (data) {  
                 var datatableVariable = $('#MatchTable').DataTable({  
                     data: data,  
                     columns: [  
                         { 'data': 'FirstName' },
                         { 'data': 'LastName' },
                         { 'data': 'UserEmail' },  
                         { 'data': 'Phone' },   
                         { 'data': 'Profession' },
                         { 'data': 'Region' },
                         { 'data': 'Skillset'}
                         ]  
                 });  
             }  
         });  
  
     });  
 </script>  
 <div class="page-header">
        <br />
        <h1>View All Candidates</h1>
        <hr />
  </div>

 <table id="MatchTable">
        <thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Profession</th>
                <th>Region</th>
                <th>Skill Sets</th>
            </tr>
        </thead>


    </table>


</asp:Content>