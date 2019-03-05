<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRegion.aspx.cs" Inherits="AddRegion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image1" ImageUrl="~/Images/Logos/PMJ@0.5x.png" runat="server" Height="43px" Width="258px" />
        <h1>Placemejob Add Region</h1>
    
        Add Region :&nbsp;
        <asp:TextBox ID="Region" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="AddRegionButton" runat="server" Height="33px" Text="Add" Width="71px" OnClick="AddRegionButton_Click" />
        <br />
        <asp:Label ID="Confirmation" runat="server"></asp:Label>
    </form>
</body>
</html>
