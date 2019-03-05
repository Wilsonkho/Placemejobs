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
  <!--   <script type="text/javascript">  
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
                       
                         { 'data': 'CoverLetter' },
                         { 'data': 'Resume' }
                         ]  
                 });  
                 /*$('#MatchTable tfoot th').each(function () {  
                     var placeHolderTitle = $('#MatchTable thead th').eq($(this).index()).text();
                     $(this).html('<input type="text" class="form-control input input-sm" placeholder = "Search ' + placeHolderTitle + '" />');  
                 });*/  
                 datatableVariable.columns().every(function () {  
                     var column = this;  
                     $(this.footer()).find('input').on('keyup change', function () {  
                         column.search(this.value).draw();  
                     });  
                 });  
                 $('.showHide').on('click', function () {  
                     var tableColumn = datatableVariable.column($(this).attr('data-columnindex'));  
                     tableColumn.visible(!tableColumn.visible());  
                 });  
             }  
         });  
  
     });  
 </script>  -->
<script type="text/javascript">  
    
     $(document).ready(function () {  
         $.ajax({  
             type: "POST",
             data: { "JobPostingID": 4 },
             dataType: "json",  
             url: "WebService.asmx/GetQualifiedCandidates",  
             success: function (data) {  
                 var datatableVariable = $('#MatchTable').DataTable({  
                     data: data,  
                     columns: [
                         {
                            "className": 'details-control', 
                            "orderable": false,
                            "data": null,
                            "defaultContent": ''
                         },
                         { 'data': 'FirstName' },
                         { 'data': 'LastName' },
                         { 'data': 'UserEmail' },  
                         { 'data': 'Phone' },   
                         { 'data': 'Profession' },
                         { 'data':'Region'},
                         { 'data': 'CoverLetter','orderable': false},
                         { 'data': 'Resume', 'orderable':false}
                     ],
                     order: [[1,'asc']]
                 });
                 $('#MatchTable tbody').on('click', 'td.details-control', function () {
                     var tr = $(this).closest('tr');
                     var row = table.row(tr);
                     window.alert("I am an alert box!");
                     if (row.child.isShown()) {
                         // This row is already open - close it
                         row.child.hide();
                         tr.removeClass('shown');
                     }
                     else {
                         // Open this row
                         row.child(format(row.data())).show();
                         tr.addClass('shown');
                     }
                 });
             
             }  
         });  
  
     });  
 </script> 
    <!--
    <script type="text/javascript">
        $(document).ready(function () {
            $('#MatchTable').DataTable();
        });
    </script>
        -->
    <table id="MatchTable">
        <thead>
            <tr>
                <th></th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Profession</th>
                <th>Region</th>
                <th>Cover</th>
                <th>Resume</th>
            </tr>
        </thead>


    </table>

</asp:Content>

