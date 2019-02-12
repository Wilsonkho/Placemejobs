<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Register Page</h3>
    <asp:Panel runat="server" ID="RegPanel" >
    <table>
        <tr>
            <td>Email address:</td>
            <td><asp:Textbox ID="UserEmail" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldvalidator1" ControlToValidate="UserEmail" Display="Dynamic" ErrorMessage="Cannot be empty." runat="server" /></td>
        </tr>
        <tr>
            <td>Password: </td>
            <td><asp:TextBox ID="UserPass" TextMode="Password" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UserPass" ErrorMessage="Cannot be empty" runat="server" /></td>
        </tr>
        
    </table>
    <asp:Label ID="Confirmation" runat="server" /><asp:HyperLink runat="server" Text="Log in now!" NavigateUrl="~/Logon.aspx" Visible="false" ID ="Login"/>
    <br />
    <asp:Button ID="Reg" OnClick="Reg_Click" Text="Register" runat="server" />
    <p><asp:Label ID="Msg" ForeColor="Red" runat="server" /></p>
    </asp:Panel>
</asp:Content>
