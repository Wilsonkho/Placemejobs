<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateRegion.aspx.cs" Inherits="UpdateRegion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <table class="auto-style1">
                 <tr>
     <asp:TableRow ID="RegionRow" runat="server">
                <asp:TableCell HorizontalAlign="Right">Region:</asp:TableCell>
                <asp:TableCell>
          <asp:DropDownList runat="server" ID="Region" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    <br /> Enter UpdatedRegion:   <asp:TextBox ID="UpdateDescription" runat="server"></asp:TextBox>                                
             <asp:Button ID="RegionUpdateButton" runat="server" Text="Submit" OnClick="RegionUpdateButton1_Click" />
              </asp:TableCell>
              </asp:TableRow>
                 </tr>
                 </table>
        <asp:Label ID="Confirmation" runat="server" Text="Label"></asp:Label>              
             &nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
  