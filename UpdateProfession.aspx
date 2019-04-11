<%@ Page Title="Update Profession" Language="C#" AutoEventWireup="true" CodeFile="UpdateProfession.aspx.cs" Inherits="UpdateProfession" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><h1 class="text-center header-blue">Modify Profession</h1><br />  
    
    <asp:Table runat="server" ID="UpdateProfessionTable" HorizontalAlign="Center" CssClass="table-active">

        <asp:TableRow ID="ProfessionRow" runat="server">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Profession:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:CompareValidator ID="ProfessionCompareValidator" runat="server" ErrorMessage="Must Select Profession" ControlToValidate="Profession" 
                        ValueToCompare="0" Operator="NotEqual" Display="None"  ></asp:CompareValidator>                   
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                <h5>New Profession Title:</h5>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="UpdateDescription" runat="server" CssClass="form-control"></asp:TextBox>     
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UpdateDescription" ErrorMessage="Must input text into New Profession Title" Display="None"></asp:RequiredFieldValidator>                           
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="ProfessionUpdateButton" runat="server" Text="Update" OnClick="ProfessionUpdateButton1_Click" CssClass="btn btn-dark" />&nbsp;&nbsp;
                <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" CssClass="btn btn-dark" OnClientClick="return AlertFunction();"/>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    <asp:ValidationSummary ShowSummary="false" ShowMessageBox="true" runat="server" />
    <script>
        function AlertFunction() {
            if (confirm('Are you sure you want to delete?')) {
                return;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>

