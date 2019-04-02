<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateProfile.aspx.cs" Inherits="CandidateProfile" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label runat="server" ID="Welcome" HorizontalAlign="Center"></asp:Label></h1>

    <asp:Table runat="server" ID="AccountDetails" HorizontalAlign="Center" Class="table-active">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <h4>Login Credentials</h4>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <button type="button" class="btn btn-info" data-toggle="modal" data-target="#ChangeEmailModal">Change Email</button>
            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#ChangePasswordModal">Change Password</button>

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
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="FirstName" ID="FirstNameRegularExpressionValidator"
                    ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for First Name." ValidationGroup="PersonalValidation" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Last Name:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="LastName" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ErrorMessage="Last Name is required."
                    ControlToValidate="LastName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="LastName" ID="LastNameRegularExpressionValidator"
                    ValidationExpression="^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed for Last Name." ValidationGroup="PersonalValidation" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Phone Number:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:TextBox runat="server" ID="Phone" Class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Phone number is required."
                    ControlToValidate="Phone" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="Phone" ID="PhoneRegularExpressionValidator"
                    ValidationExpression="[0-9]{10}" runat="server" ErrorMessage="Please enter a valid phone number (For example: 7805551234)." ValidationGroup="PersonalValidation" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Match Me With Jobs: </asp:TableCell>
            <asp:TableCell ColumnSpan="2"><asp:CheckBox runat="server" ID="Active" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button runat="server" ID="Submit" Text="Update Information" OnClick="Submit_Click" Class="btn btn-secondary" ValidationGroup="PersonalValidation" /><br />
                <asp:Label runat="server" ID="UpdatedLabel" />
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
                <asp:Button runat="server" ID="AddProfession" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddProfession_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="professionsLabel" runat="server"> </asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="SkillsetRow" runat="server">
            <asp:TableCell HorizontalAlign="Right">Skillset:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="Skillset" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddSkill_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="skillsetsLabel" runat="server"></asp:Label>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow CssClass="border-top">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Skillset:</h5></asp:TableCell>
                <asp:TableCell >
                    <asp:DropDownList runat="server" ID="DropDownList1" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="Button1" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddSkill_Click" />&nbsp
                    <asp:Button runat="server" ID="ClearSkillsButton" Text="Clear" Class="btn btn-dark" CausesValidation="false" OnClick="ClearSkillsButton_Click" 
                        ToolTip="Click to clear the list of Skills"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="border-bottom">
                <asp:TableCell ID="skillLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top"><h5>Skills:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="Label1" runat="server" CssClass="label-text"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

        <asp:TableRow ID="RegionRow" runat="server">
            <asp:TableCell HorizontalAlign="Right">Preferred Region:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" ID="Region" Wrap="true" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="AddRegion" Text="Add" Class="btn btn-secondary" CausesValidation="false" OnClick="AddRegion_Click" />
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

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Resume:</asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Button runat="server" ID="ViewResume" Text="View" OnClick="ViewResumeButton_Click" CausesValidation="false"/>
                <asp:FileUpload runat="server" ID="ResumeUpload" /><br/>
                <asp:Button runat="server" ID="ChangeResume" Text="Update" OnClick="ChangeResume_Click" CausesValidation="false" />
                <asp:Label runat="server" ID="ResumeMsg" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">Cover Letter:</asp:TableCell>
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
                                    ControlToValidate="OldPassword" Display="Dynamic" ValidationGroup="ValidatePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                New Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="NewPassword" Class="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password is required."
                                    ControlToValidate="NewPassword" Display="Dynamic" ValidationGroup="ValidatePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>
                                Confirm Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox runat="server" ID="ConfirmPassword" Class="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ValidatePassword" ErrorMessage="Password confirmation is required."
                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmPassword" ErrorMessage="Passwords do not match. Please ensure passwords are the same." Display="Dynamic" ForeColor="Red" />
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
                        ControlToValidate="EmailTextBox" Display="Dynamic" ValidationGroup="ValidateEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="EmailTextBox" ID="RegularExpressionValidator1"
                        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" runat="server" ErrorMessage="Please enter a valid email address (For example: example@email.com)." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary">Change Password</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $('#myModal').on('shown.bs.modal', function () {
            $('#myInput').trigger('focus')
        })
        

    </script>
</asp:Content>
