<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateProfile.aspx.cs" Inherits="CandidateProfile" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">


    <asp:Table runat="server" ID="AccountDetails" HorizontalAlign="Center" Class="table-active">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" CssClass="label-text">
                <h4>Login Credentials</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#ChangeEmailModal">Change Email</button>
                <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#ChangePasswordModal">Change Password</button>
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow CssClass="border-top">
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" CssClass="label-text">
                <h4>Personal Information</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right"><h5 class="label-text">First Name:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="FirstName" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ErrorMessage="First Name is required." ValidationGroup="PersonalValidation"
                    ControlToValidate="FirstName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="None" ControlToValidate="FirstName" ID="FirstNameRegularExpressionValidator"
                    ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for First Name." ValidationGroup="PersonalValidation" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right"><h5 class="label-text">Last Name:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="LastName" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ErrorMessage="Last Name is required." ValidationGroup="PersonalValidation"
                    ControlToValidate="LastName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="None" ControlToValidate="LastName" ID="LastNameRegularExpressionValidator"
                    ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for Last Name." ValidationGroup="PersonalValidation" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right"><h5 class="label-text">Phone Number:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="Phone" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Phone number is required." ValidationGroup="PersonalValidation"
                    ControlToValidate="Phone" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="None" ControlToValidate="Phone" ID="PhoneRegularExpressionValidator"
                    ValidationExpression="[0-9]{10}" runat="server" ErrorMessage="Please enter a valid phone number (For example: 7805551234)." ValidationGroup="PersonalValidation" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell><h5 class="label-text">Match Me With Jobs:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2"><asp:CheckBox runat="server" ID="Active" ToolTip="Check for yes" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button runat="server" ID="Submit" Text="Update Information" OnClick="Submit_Click" Class="btn btn-dark" ValidationGroup="PersonalValidation" /><br />
                <asp:Label runat="server" ID="UpdatedLabel" />
            </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow CssClass="border-top">
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" CssClass="label-text">
                <h4>Skills & Preferences</h4>
            </asp:TableCell>
        </asp:TableRow>

              <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Profession:</h5></asp:TableCell>
                <asp:TableCell >
                    <asp:DropDownList runat="server" ID="Profession" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="AddProfession" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddProfession_Click" />&nbsp
                    <asp:Button runat="server" ID="ClearProfession" Text="Clear" Class="btn btn-dark" CausesValidation="false" OnClick="ClearProfession_Click"
                        ToolTip="Click to clear the list of Profession"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ID="ProfessionLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top"><h5>Professions:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="professionsLabel" runat="server" CssClass="label-text" Font-Italic="true"><h5>Professions:</h5></asp:Label>
                </asp:TableCell>
            </asp:TableRow>


        <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Skillset:</h5></asp:TableCell>
                <asp:TableCell >
                    <asp:DropDownList runat="server" ID="Skillset" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="Button1" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddSkill_Click" />&nbsp
                    <asp:Button runat="server" ID="ClearSkillsButton" Text="Clear" Class="btn btn-dark" CausesValidation="false" OnClick="ClearSkillsButton_Click" 
                        ToolTip="Click to clear the list of Skills"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ID="skillLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top"><h5>Skills:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="skillsetsLabel" runat="server" CssClass="label-text" Font-Italic="true"><h5>Skills:</h5></asp:Label>
                </asp:TableCell>
            </asp:TableRow>



              <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Preferred Region:</h5></asp:TableCell>
                <asp:TableCell >
                    <asp:DropDownList runat="server" ID="Region" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="AddRegion" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddRegion_Click" />&nbsp
                    <asp:Button runat="server" ID="ClearRegion" Text="Clear" Class="btn btn-dark" CausesValidation="false" OnClick="ClearRegion_Click"
                        ToolTip="Click to clear the list of regions"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow >
                <asp:TableCell ID="regionLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top"><h5>Regions:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="regionsLabel" runat="server" CssClass="label-text" Font-Italic="true"><h5>Regions:</h5></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="1"></asp:TableCell>
            <asp:TableCell ColumnSpan="2"><asp:Button runat="server" ID="EditCategories" Text="Save Updates" Class="btn btn-dark" OnClick="EditCategories_Click"/></asp:TableCell>
        </asp:TableRow>


        <asp:TableRow CssClass="border-top">
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center" CssClass="label-text">
                <h4>Upload Documents</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right"><h5 class="label-text">Resume:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button runat="server" ID="ViewResume" Text="View" OnClick="ViewResumeButton_Click" CausesValidation="false"/>
                <asp:FileUpload runat="server" ID="ResumeUpload" /><br/>
                <asp:Button runat="server" ID="ChangeResume" Text="Update" OnClick="ChangeResume_Click" CausesValidation="false" />
                <asp:Label runat="server" ID="ResumeMsg" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right"><h5 class="label-text">Cover Letter:</h5></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button runat="server" ID="ViewCoverLetter" Text="View" OnClick="ViewCoverLetterButton_Click" CausesValidation="false" />
                <asp:FileUpload runat="server" ID="CoverLetterUpload" /><br />
                <asp:Button runat="server" ID="ChangeCoverLetter" Text="Update" OnClick="ChangeCoverLetter_Click" CausesValidation="false" />
                <asp:Label runat="server" ID="CoverLetterMsg" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Panel runat="server">
                    <asp:Label ID="Results" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label runat="server" ID="Msg" ForeColor="Red" />
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div class="modal fade" id="ChangePasswordModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ChangePasswordTitle">Change Password</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                Old Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="OldPassword" Class="form-control" TextMode="Password"></asp:TextBox>
                                <asp:HiddenField ID="HiddenField3" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Password is required."
                                    ControlToValidate="OldPassword" Display="None" ValidationGroup="ValidatePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                New Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="NewPassword" Class="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is required."
                                    ControlToValidate="NewPassword" Display="None" ValidationGroup="ValidatePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                                Confirm Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="ConfirmPassword" Class="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ValidatePassword" ErrorMessage="Password confirmation is required."
                                    ControlToValidate="ConfirmPassword" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmPassword" ErrorMessage="Passwords do not match. Please ensure passwords are the same." Display="None" ForeColor="Red" />
                            </asp:TableCell>

                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2"><asp:Label runat="server" ID="PasswordConfirmation"></asp:Label></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>                   
                    <asp:Button CssClass="btn btn-primary" ID="ChangePassword" Text="Change Password" runat="server" OnClick="ChangePassword_Click" ValidationGroup="ValidatePassword"/>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ChangeEmailModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ChangeEmail">Change Email</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:TextBox runat="server" ID="EmailTextBox" Class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email is required."
                        ControlToValidate="EmailTextBox" Display="None" ValidationGroup="ValidateEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="None" ControlToValidate="EmailTextBox" ID="RegularExpressionValidator1"
                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" runat="server" ErrorMessage="Please enter a valid email address (For example: example@email.com)." ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:Label runat="server" ID="EmailConfirmation"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                    <asp:Button CssClass="btn btn-primary" ID="ChangeEmailButton" runat="server" Text=" Udpate Email" OnClick="ChangeEmail_Click" />               
                </div>
            </div>
        </div>
    </div>
    <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ID="ValidationSummary" ValidationGroup="PersonalValidation" />

    <script type="text/javascript">
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus')
        })
        

    </script>
</asp:Content>
