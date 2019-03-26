<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyJobPosting.aspx.cs" Inherits="ModifyJobPosting" MasterPageFile="~/MasterPage.master" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-blue">
        <h1 class="text-center">Modify Job Posting</h1>
    </div>
    <br /><br />
    <%--<div id="PMJform" class=" col-7 test" >--%>
    <asp:Table runat="server" ID="SelectJobTable" HorizontalAlign="Center" CssClass="table-active table-responsive-sm">
        <asp:TableRow>
            <asp:TableCell CssClass="label-text"><h5>Select Job Posting:</h5></asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="PostingDropDown" runat="server" AppendDataBoundItems="true" AutoPostBack="true" 
                    CssClass="form-control" OnSelectedIndexChanged="PostingDropDown_SelectedIndexChanged"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table><br /><br />
    


    <asp:Table runat="server" ID="ModifyPostingTable" HorizontalAlign="Center" CssClass="table-active table-responsive-sm">


            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Job Posting Description:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="JobPostingDescription" Class="form-control"></asp:TextBox>                  
                    <asp:RequiredFieldValidator ID="JobPostingRequiredFieldValidator" runat="server" ErrorMessage="Job Posting Description is required"
                         ControlToValidate="JobPostingDescription" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Company Name:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="CompanyName" Wrap="true" Class="form-control"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Company Phone:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="CompanyPhone" Wrap="true" Class="form-control"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Posting Date:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" ID="Date" Wrap="true" Class="form-control" TextMode="Date"></asp:TextBox>                    
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
                    <asp:Label ID="skillsetsLabel" runat="server" CssClass="label-text"><h5>Skills:</h5></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Profession:</h5></asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList runat="server" ID="Profession" Class="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" CssClass="label-text"><h5>Region:</h5></asp:TableCell>
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
    <%--</div>--%>
</asp:Content>