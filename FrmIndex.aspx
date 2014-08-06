<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmIndex.aspx.vb" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="Content/bootstrap.css" rel="stylesheet" />    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
          <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
          <li data-target="#carousel-example-generic" data-slide-to="1" class=""></li>
          <li data-target="#carousel-example-generic" data-slide-to="2" class=""></li>
        </ol>
        <div class="carousel-inner">
          <div class="item active">
            <img  alt="First slide" src="images/img1.jpg">
              <div class="container">
                  <div class="carousel-caption">
                      <h1>STIN - Tiempos No Productivos</h1>
                      <p>
                          " NPT's de Perforación - Terminación - Reparación Mayor "
                      </p>
                  </div>
              </div>
          </div>
          <div class="item">
            <img alt="First slide" src="images/img2.jpg"/>
              <div class="container">
                  <div class="carousel-caption">
                      <h1>STIN - Tiempos No Productivos</h1>
                      <p>
                          " Busqueda de acuerdo a sus necesidades "
                      </p>
                  </div>
              </div>
          </div>
          <div class="item">
            <img alt="Third slide" src="images/img3.jpg">
              <div class="container">
                  <div class="carousel-caption">
                      <h1>STIN - Tiempos No Productivos</h1>
                      <p>
                          " Administración facil y rapida de NPT's "
                      </p>
                  </div>
              </div>
          </div>
        </div>
  

        <a class="left carousel-control" href="#carousel-example-generic"  data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" ></span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" ></span>
        </a>
      </div>
  
  
</asp:Content>

