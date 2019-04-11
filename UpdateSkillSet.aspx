<%@ Page Title="Update SkillSet" Language="C#" AutoEventWireup="true" CodeFile="UpdateSkillSet.aspx.cs" Inherits="UpdateSkillSet" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><h1 class="text-center header-blue">Modify Skillset</h1><br />  
    
    <asp:Table runat="server" ID="UpdateSkillsetTable" HorizontalAlign="Center" CssClass="table-active">

        <asp:TableRow runat="server">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Skillset:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Skillset" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:CompareValidator ID="SkillsetCompareValidator" runat="server" ErrorMessage="Must Select Skillset" ControlToValidate="Skillset" 
                        ValueToCompare="0" Operator="NotEqual" Display="None"  ></asp:CompareValidator>                   
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                <h5>New Skillset Title:</h5>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="UpdateSkillset" runat="server" CssClass="form-control"></asp:TextBox>     
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UpdateSkillset" ErrorMessage="Must input text into New Skillset Title" Display="None"></asp:RequiredFieldValidator>                           
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="SkillsetUpdateButton" runat="server" Text="Update" OnClick="SkillSetUpdateButton1_Click" CssClass="btn btn-dark" />&nbsp;&nbsp;
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