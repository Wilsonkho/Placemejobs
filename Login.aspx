<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPage.master"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <nav class="navbar navbar-expand-lg fixed-top navbar-light bg-light">        
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
            <a href="Default.aspx"><asp:Image runat="server" ID="PlacemejobLogo" ImageUrl="~/Images/Logos/PMJ@0.5x.png" Width="75%"/></a>
          <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
              <li class="nav-item">
                <a class="nav-link" href="Default.aspx" >Home</a>
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

</asp:Content>