<%@ Page Title="Register Candidate" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterCandidate.aspx.cs" Inherits="RegisterCandidate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <h1>Register Candidate</h1>

     <asp:Table runat="server" ID="RegisterCandidateTable">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Email:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="EmailTextBox"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required"
                         ControlToValidate="EmailTextBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">First Name:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="FirstName"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Last Name:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="LastName"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" ID="CVUpload" Text="Upload CV"/>
                </asp:TableCell>
            </asp:TableRow>
         </asp:Table>
        <br /><hr /><br />
        <asp:Table runat="server" ID="RegisterCandidateTable2">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Profession:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="Profession" Wrap="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Skillset:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Skillset" Wrap="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="AddSkill" Text="Add" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">Region:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="Region" Wrap="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="Submit" Text="Submit Candidate" /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="Cancel" Text="Clear" OnClientClick="this.form.reset();return false;" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
</asp:Content>