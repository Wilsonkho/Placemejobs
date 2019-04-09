
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSkillSet.aspx.cs" Inherits="AddSkillSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 215px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image1" ImageUrl="~/images/Logos/PMJ@0.5x.png" runat="server" Height="37px" Width="207px" />
        <h1>Placemejob Add SkillSet</h1> 
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Add Skillset:</td>
                <td> <asp:TextBox ID="SkillsetDescription" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">select Profession:</td>
                <td> <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                     </td>
            </tr>
        </table>
        &nbsp;<asp:Button ID="SkillsetAddButton" runat="server" Text="Submit" OnClick="SkillSetAddButton1_Click" />
        <br />
        <asp:Label ID="Confirmation" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
