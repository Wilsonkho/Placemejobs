<%@ Page Title="Update Region" Language="C#" AutoEventWireup="true" CodeFile="UpdateRegion.aspx.cs" Inherits="UpdateRegion" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><h1 class="text-center header-blue">Modify Region</h1><br />  
    
    <asp:Table runat="server" ID="UpdateRegionTable" HorizontalAlign="Center" CssClass="table-active">

        <asp:TableRow runat="server">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Region:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Region" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:CompareValidator ID="RegionCompareValidator" runat="server" ErrorMessage="Must Select Region" ControlToValidate="Region" 
                        ValueToCompare="0" Operator="NotEqual" Display="None"  ></asp:CompareValidator>                   
                </asp:TableCell>
        </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell CssClass="label-text">
                    <h5>New Region Title:</h5>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="RegionUpdated" CssClass="form-control" ></asp:TextBox> 
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="RegionUpdated" ErrorMessage="Must input text into New Region Title" Display="None"></asp:RequiredFieldValidator>                           
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Button ID="RegionUpdateButton" runat="server" Text="Update" OnClick="RegionUpdateButton1_Click" CssClass="btn btn-dark" />&nbsp;&nbsp;
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
  