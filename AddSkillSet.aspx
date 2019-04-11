<%@ Page Title="Add SkillSet" Language="C#" AutoEventWireup="true" CodeFile="AddSkillSet.aspx.cs" Inherits="AddSkillSet" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<br /><br /><h1 class="text-center header-blue">Add New Skillset</h1><br />



     <asp:Table ID="SkillsetTable" runat="server" CssClass="table-active" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                <h5>Skillset:</h5>
            </asp:TableCell>
            <asp:TableCell>                
                <asp:TextBox ID="Skillset" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Skillset" ErrorMessage="Must input text in Skillset" Display="None"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="AddSkillsetButton" runat="server" class="btn btn-dark" Text="Add" OnClick="SkillSetAddButton1_Click" />
            </asp:TableCell>
        </asp:TableRow>
        
        </asp:Table>
    <asp:ValidationSummary ShowSummary="false" ShowMessageBox="true" runat="server" />
</asp:Content>