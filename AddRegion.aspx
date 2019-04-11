<%@ Page Title="Add Region" Language="C#" AutoEventWireup="true" CodeFile="AddRegion.aspx.cs" Inherits="AddRegion"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <br /><br /><h1 class="text-center header-blue">Add Region</h1><br />
       

    <asp:Table ID="SkillsetTable" runat="server" CssClass="table-active" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                <h5>Region:</h5>
            </asp:TableCell>
            <asp:TableCell>                
                <asp:TextBox ID="Region" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Region" ErrorMessage="Must input text in Region" Display="None"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="AddRegionButton" runat="server" class="btn btn-dark" Text="Add" OnClick="AddRegionButton_Click" />
            </asp:TableCell>
        </asp:TableRow>
  
        </asp:Table>
    <asp:ValidationSummary ShowSummary="false" ShowMessageBox="true" runat="server" />
    </asp:Content>
