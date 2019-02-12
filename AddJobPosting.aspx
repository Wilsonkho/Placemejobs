<%@ Page Title="Add Job Posting" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddJobPosting.aspx.cs" Inherits="AddJobPosting" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <h1>Add Job Posting</h1>

     <asp:Table runat="server" ID="AddPostingTable">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Job Posting Title:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="JobPostingTitleTextBox"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="JobPostingRequiredFieldValidator" runat="server" ErrorMessage="Job Posting Title is required"
                         ControlToValidate="JobPostingTitleTextBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Skillset:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="Skillset"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Region:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Region"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Description:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="Description" Wrap="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="Submit" Text="Submit" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="Cancel" Text="Clear" OnClientClick="this.form.reset();return false;" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
</asp:Content>
