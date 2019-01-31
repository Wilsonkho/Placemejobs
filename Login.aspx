<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <title>Placemejobs - Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Login Page</h3>
    
    <table>
        <tr>
            <td>Email address:</td>
            <td><asp:Textbox ID="UserEmail" runat="server" Text="tester@email.com" /></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldvalidator1" ControlToValidate="UserEmail" Display="Dynamic" ErrorMessage="Cannot be empty." runat="server" /></td>
        </tr>
        <tr>
            <td>Password: </td>
            <td><asp:TextBox ID="UserPass" TextMode="Password" runat="server" Text="password" /></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UserPass" ErrorMessage="Cannot be empty" runat="server" /></td>
        </tr>
        <tr>
            <td>Remember me?<asp:CheckBox ID="Persist" runat="server" /></td>
            <td></td>
        </tr>
        
    </table>
    <asp:Button ID="LoginButton" OnClick="Login_Click" Text="Login" runat="server" />
    <p><asp:Label ID="Msg" ForeColor="Red" runat="server" /></p>

    </form>
</body>
</html>
