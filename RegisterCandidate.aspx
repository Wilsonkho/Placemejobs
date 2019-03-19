<%@ Page Title="Register Candidate" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterCandidate.aspx.cs" Inherits="RegisterCandidate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <br /><br />
            <h1 class="text-center">Register Candidate</h1>
         <br />
     <asp:Table runat="server" ID="RegisterCandidateTable" HorizontalAlign="Center" Class="table-active">




            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text" >First Name:</asp:TableCell>
                <asp:TableCell  ColumnSpan="2">
                    <asp:TextBox runat="server" ID="FirstName" Class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ErrorMessage="First Name is required"
                         ControlToValidate="FirstName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "FirstName" ID="FirstNameRegularExpressionValidator" 
                         ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for First Name" ForeColor="Red"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Last Name:</asp:TableCell>
                <asp:TableCell  ColumnSpan="2">
                    <asp:TextBox runat="server" ID="LastName" Class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ErrorMessage="Last Name is required"
                         ControlToValidate="LastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "LastName" ID="LastNameRegularExpressionValidator" 
                         ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for Last Name" ForeColor="Red"></asp:RegularExpressionValidator>
                    </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Phone:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="Phone" Class="form-control"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Phone is required"
                         ControlToValidate="Phone" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Phone" ID="PhoneRegularExpressionValidator" 
                         ValidationExpression = "[0-9]{10}" runat="server" ErrorMessage="Phone Format must be like 7805551234" ForeColor="Red"></asp:RegularExpressionValidator>
                    <%--^((\+)?(\d{2}[-])?(\d{10}){1})?(\d{11}){0,1}?$ (India Phone Regex)--%>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Email:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="EmailTextBox" Class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required"
                         ControlToValidate="EmailTextBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate="EmailTextBox" ID="EmailRegularExpressionValidator" 
                         ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" runat="server" ErrorMessage="Email must be like test@fmail.com" ForeColor="Red"></asp:RegularExpressionValidator>                                      
                </asp:TableCell>
            </asp:TableRow>            
         
            <asp:TableRow ID="ProfessionRow" runat="server">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Profession:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true">
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="AddProfession" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddProfession_Click"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" CssClass="label-text">
                    <asp:Label ID="professionsLabel" runat="server">Professions: </asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="SkillsetRow" runat="server">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Skillset:</asp:TableCell>
                <asp:TableCell >
                    <asp:DropDownList runat="server" ID="Skillset" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell  >
                    <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddSkill_Click" PostBackUrl/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" CssClass="label-text">
                    <asp:Label ID="skillsetsLabel" runat="server">Skills: </asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow ID="RegionRow" runat="server">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Region:</asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Region" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell  >
                    <asp:Button runat="server" ID="AddRegion" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddRegion_Click"/>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
                <asp:TableCell ColumnSpan="3" CssClass="label-text">
                    <asp:Label ID="regionsLabel" runat="server">Regions: </asp:Label>
                </asp:TableCell>
            </asp:TableRow>

         <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Resume:</asp:TableCell>
                <asp:TableCell ColumnSpan="2" CssClass="label-text">
                    <asp:FileUpload runat="server" ID="ResumeUpload" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text">Cover Letter:</asp:TableCell>
                <asp:TableCell ColumnSpan="2" CssClass="label-text">
                    <asp:FileUpload runat="server" ID="CoverLetterUpload" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <asp:Panel runat="server">           
                        <asp:Label ID="Results" runat="server" ForeColor="Red"></asp:Label>
                    </asp:Panel>                    
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Submit" Text="Submit Candidate" OnClick="Submit_Click" Class="btn btn-secondary"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Cancel" Text="Clear"  Class="btn btn-secondary" OnClick="Cancel_Click" CausesValidation="false"/></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label runat="server" ID="Msg" />
        <br /><br />
</asp:Content>