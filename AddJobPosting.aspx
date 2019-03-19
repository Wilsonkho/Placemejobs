<%@ Page Title="Add Job Posting" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddJobPosting.aspx.cs" Inherits="AddJobPosting" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
                  <br /><br />
            <h1 class="text-center">Add Job Posting</h1>
         <br />

     <asp:Table runat="server" ID="AddPostingTable" HorizontalAlign="Center" CssClass="table-active">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Job Posting Title:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="JobPostingTitleTextBox" Class="form-control"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="JobPostingRequiredFieldValidator" runat="server" ErrorMessage="Job Posting Title is required"
                         ControlToValidate="JobPostingTitleTextBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Skillset:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Skillset" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell  >
                    <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddSkill_Click"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <asp:Label ID="skillsetsLabel" runat="server">Skills: </asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Profession:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Profession" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Region:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Region" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Description:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="Description" Wrap="true" Class="form-control"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Submit" Text="Submit" class="btn btn-secondary"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Cancel" Text="Clear" OnClientClick="this.form.reset();return false;" class="btn btn-secondary"/></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
</asp:Content>
