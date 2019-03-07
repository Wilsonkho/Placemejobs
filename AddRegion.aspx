<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRegion.aspx.cs" Inherits="AddRegion"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <h1>Placemejob Add Region</h1>
    
        Add Region :&nbsp;
        <asp:TextBox ID="Region" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="AddRegionButton" runat="server" Height="33px" Text="Add" Width="71px" OnClick="AddRegionButton_Click" />
        <br />
        <asp:Label ID="Confirmation" runat="server"></asp:Label>
    </asp:Content>
