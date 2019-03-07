<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSkillSet.aspx.cs" Inherits="AddSkillSet" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <h1>Placemejob Add SkillSet</h1>
   
        
    <asp:Table ID="SkillsetTable" runat="server">
         <asp:TableRow ID="ProfessionRow" runat="server">
                <asp:TableCell>Profession:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                Skillset:
                <asp:TextBox ID="SkillSet" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="AddSkillSetButton" runat="server" Height="33px" Text="Add" Width="71px" OnClick="AddSkillSetButton_Click"  />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Confirmation" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
        </asp:Table>
    </asp:Content>