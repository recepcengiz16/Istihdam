<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Iletisim.aspx.cs" Inherits="Istıhdam.Iletisim" %>

<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8"/>
        <title>İletişim</title>
        <meta name="viewport" content="width=device-width,initial-scale=1, shrink-to-fit=no"/>        
        <link rel="stylesheet" href="css/normalize.css">
        <link rel="stylesheet" href="css/main.css">
        <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/still.css" rel="stylesheet"/>
        <link href="css/iletisim.css" rel="stylesheet"/>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css"/>
        <style type="text/css">
            .auto-style1 {
                height: 43px;
            }
        </style>
    </head>
<body style="height: 170px">
<form runat="server" method="post">
  <!--HEADER KISMI-->
  <div class="header">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Bir destek de benden</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav m-lg-auto">
            <li class="nav-item">
              <a class="nav-link" href="Index.aspx">Ana Sayfa</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="Urunler.aspx">Ürünlerimiz</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="Uyegiris.aspx">Üye/Üye Ol</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="Iletisim.aspx">İletişim</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>

     <!--İÇERİK KISMI-->
     <div class="container contact-form">
      <div class="contact-image">
          <img src="img/mesaj.png" alt="mesaj"/><br />
          <br />
          <br />
          <br />
          <br />
          <h3 class="auto-style1">Bize Mesajınızı İletiniz</h3>
         </div>
         <div class="row">
              <div class="col-md-6">
                  <div class="form-group mb-3">
                    <label ID="adilbl" runat="server" style="color: black;font-weight:bold">Adınız</label>
                    <asp:TextBox ID="aditxt" runat="server" CssClass="form-control" Width="180px"></asp:TextBox>
                  </div>
                  
                  <div class="form-group mb-3">
                    <label ID="soyadlbl" runat="server" style="color: black;font-weight:bold">Soyadınız</label>
                    <asp:TextBox ID="soyadaditxt" runat="server" CssClass="form-control" Width="180px"></asp:TextBox>
                  </div>
                  <div class="form-group mb-3">
                      <label ID="emaillbl" runat="server" style="color: black;font-weight:bold">E mail adresiniz</label>
                      <asp:TextBox ID="emailadresitxt" runat="server" CssClass="form-control" TextMode="Email" Width="180px"></asp:TextBox>
                  </div>
              </div>
              <div class="col-md-6">
                  <div class="form-group mb-3">
                        <label ID="mesajlbl" runat="server" style="color: black;font-weight:bold">Mesajınız</label>
                        <asp:TextBox ID="mesajtxt" runat="server" CssClass="form-control" Height="100px" TextMode="MultiLine" Width="431px" Rows="5"></asp:TextBox>    
                  </div>
                  <div class="form-group mb-5" >
                    <asp:Button ID="gonderbtn" runat="server" CssClass="btn btn-danger" Text="Gönder" />
                  </div>
              </div>
          </div>
      
</div>
  </form>  
    <script src="js/modernizr-3.11.2.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/main.js"></script>
    <script src="js/jquery-3.5.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
    
    <script>
      window.ga = function () { ga.q.push(arguments) }; ga.q = []; ga.l = +new Date;
      ga('create', 'UA-XXXXX-Y', 'auto'); ga('set', 'anonymizeIp', true); ga('set', 'transport', 'beacon'); ga('send', 'pageview')
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://www.google-analytics.com/analytics.js" async></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>