<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forms Authentication = Default Page</title>
</head>
<body>
    
    <h3>Using Forms Authentication</h3>
        <asp:Label ID="Welcome" runat="server" />
    <form id="form1" runat="server">
        <p><asp:Button ID="SignOutButton" OnClick="Signout_Click" Text="Sign Out" runat="server" /></p>
    </form>
</body>
</html>
