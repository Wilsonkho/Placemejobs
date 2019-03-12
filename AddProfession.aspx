<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProfession.aspx.cs" Inherits="AddProfession"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <br /><br /><h1 class="text-center">Add New Profession</h1><br />


    <asp:Table ID="SkillsetTable" runat="server" CssClass="table-active" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                Profession:
            </asp:TableCell>
            <asp:TableCell>                
                <asp:TextBox ID="Profession" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="AddProfessionButton" runat="server" class="btn btn-secondary" Text="Add" OnClick="AddProfessionButton_Click"  />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="Confirmation" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
        </asp:Table>
    </asp:Content>