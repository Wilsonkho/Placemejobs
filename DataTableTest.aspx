<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataTableTest.aspx.cs" Inherits="DataTableTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-3.3.1.js"></script>
    <link rel="stylesheet" type="text/css" href="http://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" />
    <script type="text/javascript" charset="utf8" src="http://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>
        <script>
        $(document).ready(function () {

            $('#MatchTable').DataTable();
        });
    </script>

    <title>Test Data Table</title>
</head>
<body>
    <form id="form1" runat="server">
    <table id="MatchTable">
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
                <td>mickeymouse@gmail.com</td>
                <td>Cover Letter</td>
                <td>Resume</td>
            </tr>
            <tr>
                <td>Mickey Mouse</td>
                <td>Accountant</td>
                <td>Ghatkopar</td>
                <td>7809514242</td>
                <td>mickeyhere@gmail.com</td>
                <td>Cover Letter</td>
                <td>Resume</td>
            </tr>
            <tr>
                <td>Mickey Mouse</td>
                <td>Accountant</td>
                <td>Ghatkopar</td>
                <td>7809514242</td>
                <td>mickeyhere@gmail.com</td>
                <td>Cover Letter</td>
                <td>Resume</td>
            </tr>
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
    </form>


</body>

</html>

