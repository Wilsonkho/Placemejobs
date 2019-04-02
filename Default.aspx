<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%--    <h3>Using Forms Authentication</h3>
    <asp:Label ID="Welcome" runat="server" />
    <p><asp:Button ID="Button1" OnClick="Signout_Click" Text="Sign Out" runat="server" /></p>--%>
    <link href="Themes/Default/StyleSheet.css" rel="stylesheet" />

  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>
    <div class="carousel-inner">
      <div class="carousel-item active ">
          <img src="Images/banner1.jpg" height="65%" width="100%" />
        <div class="container">
          <div class="carousel-caption text-left">
            <h1>Example headline.</h1>
            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
            <p><a class="btn btn-lg btn-primary" href="#" role="button">Sign up today</a></p>
          </div>
        </div>
      </div>
      <div class="carousel-item">
          <img src="Images/banner2.jpg" height="65%" width="100%" />
         <div class="container">
          <div class="carousel-caption text-left">
            <h1>Another example headline.</h1>
            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
            <p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>
          </div>
        </div>
      </div>
      <div class="carousel-item">
          <img src="Images/banner4.jpg" height="65%" width="100%" />
          <div class="container">
          <div class="carousel-caption text-left">
            <h1>One more for good measure.</h1>
            <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
            <p><a class="btn btn-lg btn-primary" href="#" role="button">Browse gallery</a></p>
          </div>
        </div>
      </div>
    </div>
    <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a><br /><br />
  </div>


<div class="container">

    <hr class="featurette-divider">

    <h2 class="featurette-heading">About Placemejob</h2>
    <p class="lead">Placemejob.com is a startup recruitment agency with the vision of providing a single stop solution for organization's recruitment requirements. 
        Organizations need right talent to grow and Right talent need right opportunity to work. India is the country where talented resources are available and if 
        provided with right opportunity they can perform their best to take organization to elevated heights. Our team is continuously in touch with the prospective 
        Employers and job aspirants to provide the best solutions which can meet both side requirements.</p>
    <p class="lead">Candidates / working professionals are encouraged to send their CVs/ resumes to CV@placemejob.com to move forward on their career path. 
        We believe that career building is a continuous process for each person and we provide career solutions to all job aspirants. Every CV is considered 
        seriously and based on the availability of suitable openings, it is positioned to prospective employer for hirings. If you are a corporate employer 
        please get in touch with us and we shall be more than happy to assist you to meet your requirements.</p>



  </div><!-- /.container -->
</asp:Content>

