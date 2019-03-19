<%@ Page Title="Add Job Posting" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddJobPosting.aspx.cs" Inherits="AddJobPosting" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
                  <br /><br />
        <div class="header-blue">
            <h1 class="text-center">Add Job Posting</h1>
        </div>
         <br />

     <asp:Table runat="server" ID="AddPostingTable" HorizontalAlign="Center" CssClass="table-active">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Job Posting Description:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="JobPostingDescription" Class="form-control"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="JobPostingRequiredFieldValidator" runat="server" ErrorMessage="Job Posting Description is required"
                         ControlToValidate="JobPostingDescription" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Company Name:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="CompanyName" Wrap="true" Class="form-control"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Company Phone:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="CompanyPhone" Wrap="true" Class="form-control"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Posting Date:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="Date" Wrap="true" Class="form-control" TextMode="Date"></asp:TextBox>                    
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Skillset:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Skillset" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddSkill_Click"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <asp:Label ID="skillsetsLabel" runat="server" CssClass="label-text">Skills: </asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Profession:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Profession" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Region:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Region" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Submit" Text="Submit" class="btn btn-dark" OnClick="Submit_Click"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Cancel" Text="Clear" OnClientClick="this.form.reset();return false;" class="btn btn-dark"/></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <asp:Label ID="Confirmation" runat="server"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
</asp:Content>
