<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSkillSet.aspx.cs" Inherits="AddSkillSet" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <br /><br /><h1 class="text-center">Add New SkillSet</h1><br />
   
        
    <asp:Table ID="SkillsetTable" runat="server" CssClass="table-active" HorizontalAlign="Center">
         <asp:TableRow ID="ProfessionRow" runat="server">           
             <asp:TableCell>
                Profession:
             </asp:TableCell> 
                <asp:TableCell>                     
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                Skillset:
            </asp:TableCell>
            <asp:TableCell>                
                <asp:TextBox ID="SkillSet" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="AddSkillSetButton" runat="server" class="btn btn-secondary" Text="Add"  OnClick="AddSkillSetButton_Click"  />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="Confirmation" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
        </asp:Table>
    </asp:Content>