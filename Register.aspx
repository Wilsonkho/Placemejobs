<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<link href="Themes/MasterPage/StyleSheet.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Placemejobs - Registration</title>
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
              </li>
            </ul>
          </div>
        </nav>
        <div>
            <br /><br /><br />
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
        </div>
    </form>
</body>
</html>
