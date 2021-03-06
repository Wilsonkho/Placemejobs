﻿<%@ Page Title="Add Job Posting" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddJobPosting.aspx.cs" Inherits="AddJobPosting" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
                  <br /><br />
        <div class="header-blue">
            <h1 class="text-center">Add Job Posting</h1>
        </div>
         <br />

     <asp:Table runat="server" ID="AddPostingTable" HorizontalAlign="Center" CssClass="table-active">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Job Posting Description:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="JobPostingDescription" Class="form-control"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="JobPostingRequiredFieldValidator" runat="server" ErrorMessage="Job Posting Description is required"
                         ControlToValidate="JobPostingDescription" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="JobPostingValidator" runat="server" Display="None" ErrorMessage="Job Posting Description must be less than 3000 characters" ForeColor="Red"
                    ControlToValidate="JobPostingDescription" ValidationExpression="^.{0,3000}$" ></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Company Name:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="CompanyName" Wrap="true" Class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CompanyNameRequiredFieldValidator" runat="server" ErrorMessage="Company name is required"
                         ControlToValidate="CompanyName" Display="None" ForeColor="Red" BackColor="PaleVioletRed"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CompanyNameRegularExpressionValidator" runat="server" Display="None" ErrorMessage="Company Name must be less than 100 characters" ForeColor="Red"
                    ControlToValidate="CompanyName" ValidationExpression="^.{0,100}$" ></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Company Phone:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="CompanyPhone" Wrap="true" Class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CompanyPhoneRequiredFieldValidator" runat="server" ErrorMessage="Company Phone is required"
                         ControlToValidate="CompanyPhone" Display="None" ForeColor="Red" BackColor="PaleVioletRed"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display = "None" ControlToValidate = "CompanyPhone" ID="PhoneRegularExpressionValidator" 
                         ValidationExpression = "[0-9]{10}" runat="server" ErrorMessage="Phone Format must be like 7805551234" ForeColor="Red"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Posting Date:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="Date" Wrap="true" Class="form-control" TextMode="Date"></asp:TextBox>   
                    <asp:RequiredFieldValidator ID="DateRequiredFieldValidator" runat="server" ErrorMessage="Date is required"
                         ControlToValidate="Date" Display="None" ForeColor="Red" BackColor="PaleVioletRed"></asp:RequiredFieldValidator>                             
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="border-top">
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Skillset:</h5></asp:TableCell>
                <asp:TableCell >
                    <asp:DropDownList runat="server" ID="Skillset" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="AddSkill" Text="Add" Class="btn btn-dark" CausesValidation="false" OnClick="AddSkill_Click" />&nbsp
                    <asp:Button runat="server" ID="ClearSkillsButton" Text="Clear" Class="btn btn-dark" CausesValidation="false" OnClick="ClearSkillsButton_Click" 
                        ToolTip="Click to clear the list of Skills"/>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow CssClass="border-bottom">
                <asp:TableCell ID="skillLabel" runat="server" ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top"><h5>Skills:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="skillsetsLabel" runat="server" CssClass="label-text"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Profession:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Profession" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:CompareValidator ID="ProfessionCompareValidator" runat="server" ErrorMessage="Must Select Profession" ControlToValidate="Profession" 
                        ValueToCompare="0" Operator="NotEqual" Display="None"></asp:CompareValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Region:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Region" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                    <asp:CompareValidator ID="RegionCompareValidator" runat="server" ErrorMessage="Must Select Region" ControlToValidate="Region" 
                        ValueToCompare="0" Operator="NotEqual" Display="None"></asp:CompareValidator>
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
    <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" />
        <br /><br />
</asp:Content>
