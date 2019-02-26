<%@ Page Title="Register Candidate" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterCandidate.aspx.cs" Inherits="RegisterCandidate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <br /><br />
            <h1 class="text-center">Register Candidate</h1>
         <br />
     <asp:Table runat="server" ID="RegisterCandidateTable" HorizontalAlign="Center" Class="table-active">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Email:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="EmailTextBox" Class="form-control"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required"
                         ControlToValidate="EmailTextBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" >First Name:</asp:TableCell>
                <asp:TableCell  ColumnSpan="2">
                    <asp:TextBox runat="server" ID="FirstName" Class="form-control"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Last Name:</asp:TableCell>
                <asp:TableCell  ColumnSpan="2">
                    <asp:TextBox runat="server" ID="LastName" Class="form-control"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right">Resume:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:FileUpload runat="server" ID="ResumeUpload" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right">Cover Letter:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:FileUpload runat="server" ID="CoverLetterUpload" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Profession:</asp:TableCell>
                <asp:TableCell  ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Skillset:</asp:TableCell>
                <asp:TableCell >
                    <asp:DropDownList runat="server" ID="Skillset" Wrap="true" Class="form-control"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell  >
                    <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-secondary" CausesValidation="false"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Region:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Region" Wrap="true" Class="form-control"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Submit" Text="Submit Candidate" OnClick="Submit_Click" Class="btn btn-secondary"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Cancel" Text="Clear" OnClientClick="this.form.reset();return false;" Class="btn btn-secondary"/></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label runat="server" ID="Msg" />
        <br /><br />
</asp:Content>