<%@ Page Title="Update SkillSet" Language="C#" AutoEventWireup="true" CodeFile="UpdateSkillSet.aspx.cs" Inherits="UpdateSkillSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Profession:<asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>

        <table class="auto-style1">
                 <tr>

     <asp:TableRow ID="SkillsetRow" runat="server">

                <asp:TableCell HorizontalAlign="Right">SkillSet:</asp:TableCell>
                <asp:TableCell>
           <asp:DropDownList runat="server" ID="Skillset" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
              
                    <br /> Enter UpdatedSkillSet:   <asp:TextBox ID="UpdateDescription" runat="server"></asp:TextBox>                                
             <asp:Button ID="SkillsetUpdateButton" runat="server" Text="Submit" OnClick="SkillSetUpdateButton1_Click" />
              </asp:TableCell>
              </asp:TableRow>
                 </tr>
                 </table>
        <asp:Label ID="Confirmation" runat="server" Text="Label"></asp:Label>              
             &nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>

