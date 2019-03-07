<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProfession.aspx.cs" Inherits="AddProfession"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <h1>Placemejob Add Profession</h1>
    
        Add Profession :&nbsp;
        <asp:TextBox ID="Profession" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="AddProfessionButton" runat="server" Height="33px" Text="Add" Width="71px" OnClick="AddProfessionButton_Click"  />
        <br />
        <asp:Label ID="Confirmation" runat="server"></asp:Label>
    </asp:Content>