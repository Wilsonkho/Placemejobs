<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCandidates.aspx.cs" Inherits="SearchCandidates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Search Candidates</h1>

     <asp:Table runat="server" ID="AddCustomerTable">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Job Posting:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="JobPosting">
                        <asp:ListItem>CompanyA - Java Programmer</asp:ListItem>
                        <asp:ListItem>CompanyB - Accountant</asp:ListItem>
                    </asp:DropDownList>                    
                    <asp:RequiredFieldValidator ID="JobPostingRequiredFieldValidator" runat="server" ErrorMessage="Job Posting is required"
                         ControlToValidate="JobPosting" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Title:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="Title"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Location:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="Location"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Skills:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="Skills"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="Submit" Text="Submit" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="Cancel" Text="Clear" OnClientClick="this.form.reset();return false;" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />



        <asp:Table runat="server" ID="Table1" CellPadding="7" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableCell runat="server" ID="NameHeader">Name</asp:TableCell>
                <asp:TableCell runat="server" ID="TableCell1">Location</asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="Name">Bob Ross</asp:Label>                  
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label runat="server" ID="CandidateLocation">Edmonton</asp:Label>                  
                </asp:TableCell>

                <asp:TableCell>                   
                    <asp:Button runat="server" ID="ViewCV" Text="View CV" />              
                </asp:TableCell>
                
                <asp:TableCell>                   
                    <asp:Button runat="server" ID="AssignToPosting" Text="Assign To Posting" />              
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </form>
</body>
</html>
