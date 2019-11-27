<%@ Page Title="Home" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContent" Runat="Server">

</asp:Content>


<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContnet" Runat="Server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" href="#"><img src="Images/logo.jpg" width="30" height="30"> NCOH</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarNavDropdown">
        <ul class="navbar-nav">
          <li class="nav-item active">
            <a class="nav-link" href="#">الرئيسية<span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">دور الأيتام</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">تبرع الآن</a>
          </li>
        </ul>
      </div>
      <button class="btn btn-success float-left float-lg-left">تسجيل دخول</button>
    </nav>
</asp:Content>

