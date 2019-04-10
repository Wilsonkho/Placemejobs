<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPage.master"%>

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


    <div class="header-blue">
        <h1 class="text-center">Log In</h1>
    </div>
    <br /><br />
    

    <asp:Table ID="LoginTable" runat="server" CssClass="table-active" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                <h5>Email Address:</h5>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Textbox ID="UserEmail" runat="server" Text="tester@email.com" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldvalidator1" ControlToValidate="UserEmail" Display="None" ErrorMessage="Email address cannot be empty." runat="server" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell CssClass="label-text">
                <h5>Password:</h5>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="UserPass" TextMode="Password" runat="server" Text="password" CssClass="form-control"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="UserPass" ErrorMessage="Password cannot be empty" runat="server" Display="None" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="LoginButton" OnClick="Login_Click" Text="Login" runat="server" CssClass="btn btn-dark"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:LinkButton ID="RegisterLink" runat="server" ForeColor="White" CssClass="float-right" OnClick="RegisterLink_Click" CausesValidation="false">Register?</asp:LinkButton>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" runat="server" />
            
            


</asp:Content>