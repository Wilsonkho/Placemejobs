<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="header-blue">
        <h1 class="text-center">Contact Us</h1>
    </div>
    <hr /><br />



    <div class="col-md-5 float-left">
        <asp:Table ID="ContactTable" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableCell>Address:</asp:TableCell>
                <asp:TableCell>
                    6, Chheda Sadan Shiv Mandir Road,<br />
                    Dombivali - East Thane - 421201<br />
                    Maharshatra State,<br />
                    India
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Phone:</asp:TableCell>
                <asp:TableCell>+91 - 99302 29301</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>Email:</asp:TableCell>
                <asp:TableCell>contactus@placemejob.com</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>For Organization Inquiy/Hirings</asp:TableCell>
                <asp:TableCell>employer@placemejob.com</asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>For Candidates/Job Aspirants:</asp:TableCell>
                <asp:TableCell>cv@placemejob.com</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <div class="col-md-6 float-right">
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3767.5091433535185!2d73.08580731399537!3d19.216630052532707!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be7958a79a6e973%3A0x5185d69e755ed052!2splacemejob!5e0!3m2!1sen!2sin!4v1464358462795" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>



    </div>
</asp:Content>

