<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<link href="Themes/MasterPage/StyleSheet.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Placemejobs - Login</title>
    <link href="packages/bootstrap.4.2.1/content/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="packages/jQuery.3.3.1/Content/Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg fixed-top navbar-light bg-light">        
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
            <a href="Default.aspx"><asp:Image runat="server" ID="PlacemejobLogo" ImageUrl="~/Images/Logos/PMJ@0.5x.png" Width="75%"/></a>
          <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
              <li class="nav-item">
                <a class="nav-link" href="Default.aspx" >Home</a>
              <li class="nav-item">
                <a class="nav-link" href="Register.aspx" id="Register" >Registration</a>                  
              </li>
            </ul>
          </div>
        </nav>
        <div>
            <br /><br /><br />
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
        </div>
    </form>
</body>
</html>
