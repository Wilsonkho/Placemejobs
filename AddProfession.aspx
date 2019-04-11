<%@ Page Title="Add Profession" Language="C#" AutoEventWireup="true" CodeFile="AddProfession.aspx.cs" Inherits="AddProfession"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <br /><br /><h1 class="text-center header-blue">Add New Profession</h1><br />


    <asp:Table ID="SkillsetTable" runat="server" CssClass="table-active" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                <h5>Profession:</h5>
            </asp:TableCell>
            <asp:TableCell>                
                <asp:TextBox ID="Profession" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Profession" ErrorMessage="Must input text in Profession" Display="None"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="AddProfessionButton" runat="server" class="btn btn-dark" Text="Add" OnClick="AddProfessionButton_Click"  />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" CssClass="label-text">
                <asp:Label ID="Confirmation" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
        </asp:Table>
    <asp:ValidationSummary ShowSummary="false" ShowMessageBox="true" runat="server" />
    </asp:Content>