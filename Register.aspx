<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <title>Forms Authentication - Register</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Register Page</h3>
    <asp:Panel runat="server" ID="RegPanel" >
    <table>
        <tr>
            <td>First Name: </td>
            <td><asp:TextBox ID="FirstNameBox" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="UserPass" ErrorMessage="Cannot be empty" runat="server" /></td>
        </tr>
        <tr>
            <td>Last Name: </td>
            <td><asp:TextBox ID="LastNameBox"  runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="UserPass" ErrorMessage="Cannot be empty" runat="server" /></td>
        </tr>
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
    <asp:Label ID="Confirmation" runat="server" /><asp:HyperLink runat="server" Text="Log in now!" NavigateUrl="~/Login.aspx" Visible="false" ID ="Login"/>
    <br />
    <asp:Button ID="Reg" OnClick="Reg_Click" Text="Register" runat="server" />
    <p><asp:Label ID="Msg" ForeColor="Red" runat="server" /></p>
    </asp:Panel>
    </form>

</body>
</html>
