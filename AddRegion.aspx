<%@ Page Title="Add Region" Language="C#" AutoEventWireup="true" CodeFile="AddRegion.aspx.cs" Inherits="AddRegion"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <br /><br /><h1 class="text-center">Add New Region</h1><br />
       

    <asp:Table ID="SkillsetTable" runat="server" CssClass="table-active" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                Region:
            </asp:TableCell>
            <asp:TableCell>                
                <asp:TextBox ID="Region" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="AddRegionButton" runat="server" class="btn btn-secondary" Text="Add" OnClick="AddRegionButton_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" CssClass="label-text">
                <asp:Label ID="Confirmation" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
        </asp:Table>
    </asp:Content>
