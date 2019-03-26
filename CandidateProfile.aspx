<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateProfile.aspx.cs" Inherits="CandidateProfile" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label runat="server" ID="Welcome" HorizontalAlign="Center"></asp:Label></h1>

    <asp:Table runat="server" ID="AccountDetails" HorizontalAlign="Center" Class="table-active">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <h4>Login Credentials</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Email:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="EmailTextBox" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email is required."
                        ControlToValidate="EmailTextBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate="EmailTextBox" ID="EmailRegularExpressionValidator" 
                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" runat="server" ErrorMessage="Please enter a valid email address (For example: example@email.com)." ForeColor="Red"></asp:RegularExpressionValidator>                                      
            </asp:TableCell>
        </asp:TableRow> 

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Password:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="Password" Class="form-control" TextMode="Password"></asp:TextBox>
                <asp:HiddenField ID="HidePassword" runat="server" />
                <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Password is required."
                        ControlToValidate="Password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow> 

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Confirm Password:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="ConfirmPassword" Class="form-control" TextMode="Password"></asp:TextBox>
                <asp:HiddenField ID="HideConfirmPassword" runat="server" />
                <asp:RequiredFieldValidator ID="ConfirmPasswordRequiredFieldValidator2" runat="server" ErrorMessage="Password confirmation is required."
                        ControlToValidate="Password" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="ComparePasswords" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="Passwords do not match. Please ensure passwords are the same." Display="Dynamic" ForeColor="Red" />
            </asp:TableCell>
        </asp:TableRow> 

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <h4>Personal Information</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">First Name:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="FirstName" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ErrorMessage="First Name is required."
                         ControlToValidate="FirstName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "FirstName" ID="FirstNameRegularExpressionValidator" 
                         ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for First Name." ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Last Name:</asp:TableCell>
            <asp:TableCell  ColumnSpan="2">
                <asp:TextBox runat="server" ID="LastName" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ErrorMessage="Last Name is required."
                        ControlToValidate="LastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "LastName" ID="LastNameRegularExpressionValidator" 
                        ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for Last Name." ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Phone Number:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="Phone" Class="form-control"></asp:TextBox>                  
                <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Phone number is required."
                        ControlToValidate="Phone" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "Phone" ID="PhoneRegularExpressionValidator" 
                        ValidationExpression = "[0-9]{10}" runat="server" ErrorMessage="Please enter a valid phone number (For example: 7805551234)." ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <h4>Skills & Preferences</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="ProfessionRow" runat="server">
            <asp:TableCell HorizontalAlign="Right">Profession:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="Profession" Wrap="true" Class="form-control" AppendDataBoundItems="true">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="AddProfession" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddProfession_Click"/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="professionsLabel" runat="server"> </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="SkillsetRow" runat="server">
            <asp:TableCell HorizontalAlign="Right">Skillset:</asp:TableCell>
            <asp:TableCell >
                <asp:DropDownList runat="server" ID="Skillset" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell  >
                <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddSkill_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="skillsetsLabel" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="RegionRow" runat="server">
            <asp:TableCell HorizontalAlign="Right">Preferred Region:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="Region" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell  >
                <asp:Button runat="server" ID="AddRegion" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddRegion_Click"/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="regionsLabel" runat="server"> </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <h4>Upload Documents</h4>
            </asp:TableCell>
        </asp:TableRow>
        
         <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right">Resume:</asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Button runat="server" ID="ViewResume" Text="View" OnClick="ViewResumeButton_Click"/>
                    <asp:FileUpload runat="server" ID="ResumeUpload"/>
                </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow >
            <asp:TableCell HorizontalAlign="Right">Cover Letter:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                    <asp:Button runat="server" ID="ViewCoverLetter" Text="View" OnClick="ViewCoverLetterButton_Click"/>
                    <asp:FileUpload runat="server" ID="CoverLetterUpload"/>
                </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3"><asp:Button runat="server" ID="Submit" Text="Submit Candidate" OnClick="Submit_Click" Class="btn btn-secondary" CausesValidation="false"/></asp:TableCell>

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