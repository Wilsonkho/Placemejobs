<%@ Page Title="Account Registration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterAccount.aspx.cs" Inherits="RegisterAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br /><br />
    <div class="header-blue">
        <h1 class="text-center">Account Registration</h1>
    </div>
    <br />
    <asp:Table runat="server" ID="AccountDetails" HorizontalAlign="Center" Class="table-active">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" CssClass="label-text">
                <h4>Personal Information</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Email:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="EmailTextBox" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required."
                        ControlToValidate="EmailTextBox" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "None" ControlToValidate="EmailTextBox" ID="EmailRegularExpressionValidator" 
                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" runat="server" 
                        ErrorMessage="Please enter a valid email address (For example: example@email.com)." ForeColor="Red"></asp:RegularExpressionValidator>                                      
            </asp:TableCell>
        </asp:TableRow> 

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Password:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="Password" Class="form-control" TextMode="Password"></asp:TextBox>
                <asp:HiddenField ID="HidePassword" runat="server" />
                <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Password is required."
                        ControlToValidate="Password" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow> 

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Confirm Password:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="ConfirmPassword" Class="form-control" TextMode="Password"></asp:TextBox>
                <asp:HiddenField ID="HideConfirmPassword" runat="server" />
                <asp:RequiredFieldValidator ID="ConfirmPasswordRequiredFieldValidator2" runat="server" ErrorMessage="Password confirmation is required."
                        ControlToValidate="Password" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ComparePasswords" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="Passwords do not match. Please ensure passwords are the same." Display="Dynamic" ForeColor="Red" />
            </asp:TableCell>
        </asp:TableRow> 

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>First Name:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="FirstName" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ErrorMessage="First Name is required."
                         ControlToValidate="FirstName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "None" ControlToValidate = "FirstName" ID="FirstNameRegularExpressionValidator" 
                         ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for First Name." ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Last Name:</h5></asp:TableCell>
            <asp:TableCell  ColumnSpan="2">
                <asp:TextBox runat="server" ID="LastName" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ErrorMessage="Last Name is required."
                        ControlToValidate="LastName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "None" ControlToValidate = "LastName" ID="LastNameRegularExpressionValidator" 
                        ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for Last Name." ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Phone Number:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="Phone" Class="form-control"></asp:TextBox>                  
                <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Phone number is required."
                        ControlToValidate="Phone" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "None" ControlToValidate = "Phone" ID="PhoneRegularExpressionValidator" 
                        ValidationExpression = "[0-9]{10}" runat="server" ErrorMessage="Please enter a valid phone number (For example: 7805551234)." ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow CssClass="border-top">
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <asp:Label runat="server" CssClass="label-text"><h4>Skills & Preferences</h4></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="ProfessionRow" runat="server">
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Profession:</h5></asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="AddProfession" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddProfession_Click"/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
                <asp:TableCell ID="ProfessionLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top" ><h5>Professions:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="professionsLabel" runat="server" CssClass="label-text" Font-Italic="true"><h5>Professions:</h5></asp:Label><hr />
                </asp:TableCell>
        </asp:TableRow>
        

        <asp:TableRow ID="SkillsetRow" runat="server">
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Skillset:</h5></asp:TableCell>
            <asp:TableCell >
                <asp:DropDownList runat="server" ID="Skillset" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell  >
                <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddSkill_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
                <asp:TableCell ID="skillLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top"><h5>Skills:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="skillsetsLabel" runat="server" CssClass="label-text" Font-Italic="true"><h5>Skills:</h5></asp:Label><hr />
                </asp:TableCell>
            </asp:TableRow>

        
        <asp:TableRow ID="RegionRow" runat="server">
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Preferred Region:</h5></asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="Region" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell  >
                <asp:Button runat="server" ID="AddRegion" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddRegion_Click"/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow >
                <asp:TableCell ID="regionLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top"><h5>Regions:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="regionsLabel" runat="server" CssClass="label-text" Font-Italic="true"><h5>Regions:</h5></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

        <asp:TableRow CssClass="border-top">
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <asp:Label runat="server" CssClass="label-text"><h4>Upload Documents</h4></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Resume:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:FileUpload runat="server" ID="ResumeUpload" />
                </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow >
            <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Cover Letter:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:FileUpload runat="server" ID="CoverLetterUpload" />
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click" Class="btn btn-dark"/></asp:TableCell>
            <asp:TableCell ColumnSpan="1"><asp:Button runat="server" ID="Clear" Text="Clear"  Class="btn btn-dark" OnClick="Clear_Click" CausesValidation="false"/></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Panel runat="server">           
                    <asp:Label ID="Results" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label runat="server" ID="Msg" ForeColor="Red"/>
                </asp:Panel>                    
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" />

    <script type="text/javascript">
      function CapturePassword() { 
          var hiddenPasswordField = document.getElementById('<%=HidePassword.ClientID %>');
          var txtPassword = document.getElementById("<%= Password.ClientID %>"); 
          hiddenPasswordField.value = txtPassword.value;
      }
    function CaptureConfirmPassword() {
        var hiddenConfirmPasswordField = document.getElementById('<%=HideConfirmPassword.ClientID %>');
        var txtConfirmPassword = document.getElementById("<%= ConfirmPassword.ClientID %>"); 
        hiddenConfirmPasswordField.value = txtConfirmPassword.value;
    }
</script>
</asp:Content>

