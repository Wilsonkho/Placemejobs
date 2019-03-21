<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateProfession.aspx.cs" Inherits="UpdateProfession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">

             <table class="auto-style1">
                 <tr>
     <asp:TableRow ID="ProfessionRow" runat="server">
                <asp:TableCell HorizontalAlign="Right">Profession:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true">
                    </asp:DropDownList> <br /> Enter UpdatedProfession:   <asp:TextBox ID="UpdateDescription" runat="server"></asp:TextBox>                                
             <asp:Button ID="ProfessionUpdateButton" runat="server" Text="Submit" OnClick="ProfessionUpdateButton1_Click" />
                                    
                   
                </asp:TableCell>
              </asp:TableRow>

                   <!--   <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click" Class="btn btn-secondary"/>-->
                 </tr>
                 </table>
        <asp:Label ID="Confirmation" runat="server" Text="Label"></asp:Label>              
             &nbsp;&nbsp;&nbsp;
                                    
    </form>
</body>
</html>

