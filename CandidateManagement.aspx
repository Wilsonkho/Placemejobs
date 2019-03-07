<%@ Page Title="Candidate Management" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidateManagement.aspx.cs" Inherits="CandidateManagement" %>
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

<script type="text/javascript">  
    
     $(document).ready(function () {  
         $.ajax({  
             type: "POST",
             data: { "JobPostingID": 4 },
             dataType: "json",  
             url: "WebService.asmx/GetQualifiedCandidates",  
             success: function (data) {
                 var datatableVariable = $('#MatchTable').DataTable({
                     "initComplete": function () {
                         var api = this.api();
                         api.$('tr').click(function () {
                             alert(this.innerHTML);
                             $.ajax({
                                 type: "POST",
                                 data: { "JobPostingID": 4 },
                                 dataType: "string",
                                 url: "WebService.asmx/ViewDocuments",
                                 success: function (data) {
                                     alert(data);
                                 }
                             });

                         });
                     },
                     data: data,  
                     columns: [
                         {'data':'UserID'},
                         { 'data': 'FirstName' },
                         { 'data': 'LastName' },
                         { 'data': 'UserEmail' },  
                         { 'data': 'Phone' },   
                         { 'data': 'CoverLetter','orderable': false},
                         { 'data': 'Resume', 'orderable':false}
                     ],
                     order: [[1, 'asc']]

                 });

             }  
         });
         //end of ajax table call

     });  
 </script> 

    <table id="MatchTable">
        <thead>
            <tr>
                <th>User ID</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Cover</th>
                <th>Resume</th>
            </tr>
        </thead>


    </table>
    <br />
    <br />


    <asp:Table ID="BasicTable" runat="server" border="1" />
</asp:Content>

