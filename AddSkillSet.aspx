
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSkillSet.aspx.cs" Inherits="AddSkillSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:Image ID="Image1" ImageUrl="~/Images/Logos/PMJ@0.5x.png" runat="server" Height="43px" Width="258px" />
        <h1>Placemejob Add SkillSet</h1>
    
        Add SkillSet :&nbsp;
        <asp:TextBox ID="SkillSet" runat="server"></asp:TextBox><br />
         <asp:TableRow ID="ProfessionRow" runat="server">
                <asp:TableCell HorizontalAlign="Right">Profession:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </asp:TableCell>

            </asp:TableRow>
        <br />
        <asp:Button ID="AddSkillSetButton" runat="server" Height="33px" Text="Add" Width="71px" OnClick="AddSkillSetButton_Click"  />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
