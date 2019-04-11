<%@ Page Title="Update Profession" Language="C#" AutoEventWireup="true" CodeFile="UpdateProfession.aspx.cs" Inherits="UpdateProfession" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <br /><br /><h1 class="text-center">Modify Profession</h1><br />  
    
    <asp:Table runat="server" ID="UpdateProfessionTable" HorizontalAlign="Center" CssClass="table-active">

        <asp:TableRow ID="ProfessionRow" runat="server">
                <asp:TableCell HorizontalAlign="Right">Profession:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>                     
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Enter Updated Profession:      
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="UpdateDescription" runat="server" CssClass="form-control"></asp:TextBox>                                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="ProfessionUpdateButton" runat="server" Text="Update" OnClick="ProfessionUpdateButton1_Click" CssClass="btn btn-dark" />&nbsp;&nbsp;
                <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" CssClass="btn btn-dark" />
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
</asp:Content>

