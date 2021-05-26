<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uyegiris.aspx.cs" Inherits="Istıhdam.Uyegiris" %>

<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8"/>
        <title>Üye Ol</title>
        <meta name="viewport" content="width=device-width,initial-scale=1, shrink-to-fit=no"/>        
        <link rel="stylesheet" href="css/normalize.css">
        <link rel="stylesheet" href="css/main.css">
        <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/still.css" rel="stylesheet"/>
        <link href="css/login.css" rel="stylesheet"/>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css"/>
        <style type="text/css">
            .auto-style1 {
                display: block;
                font-size: 1rem;
                font-weight: 400;
                line-height: 1.5;
                color: #212529;
                background-clip: padding-box;
                -webkit-appearance: none;
                -moz-appearance: none;
                appearance: none;
                border-radius: .25rem;
                transition: none;
                border: 1px solid #ced4da;
                background-color: #fff;
            }
        </style>
    </head>
<body style="height: 204px">
    <form runat="server">
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
    <div class="container login-container">
      <div class="row">
          <div class="col-md-6 login-form-1">
              
              <h4 style="color: white;">Site Üye Giriş</h4>  
                  <div class="form-group" style="margin-bottom: 10px;">
                      <label ID="musteriadlbl" runat="server" style="color: #FFFFFF">Kullanıcı Adı</label>
                      <asp:TextBox ID="musteriaditxt" runat="server" CssClass="auto-style1" Width="291px"></asp:TextBox>
                  </div>
                  <div class="form-group">
                      <label ID="musterisifrelbl" runat="server" style="color: #FFFFFF">Şifre</label>
                      <asp:TextBox ID="musterisifretxt" runat="server" CssClass="auto-style1" TextMode="Password" Width="290px"></asp:TextBox>
                  </div>
                  <div class="form-group">
                      <asp:Button ID="musterigirisbtn" runat="server" CssClass="btnSubmit" Text="Giriş" OnClick="musterigirisbtn_Click" />
                      <asp:Button ID="musterikayitbtn" runat="server" CssClass="btn btn-danger" Text="Kayıt Ol" OnClick="musterikayitbtn_Click"/>
                  </div>
                  <div class="form-group">
                      <asp:Label ID="musterimesajlbl" runat="server" ForeColor="Aqua"></asp:Label>
                  </div>   
          </div>
          <div class="col-md-6 login-form-2">
              <div class="login-logo">
                  <img src="img/profil2.png" alt="profil"/>
              </div>
              <h4>Sitede Satış Yapmak İstiyorum</h4>
                  <div class="form-group" style="margin-bottom: 10px;">
                      <label ID="saticiadilbl" runat="server" style="color: #FFFFFF">Kullanıcı Adı</label>
                      <asp:TextBox ID="saticiaditxt" runat="server" CssClass="auto-style1" Width="290px"></asp:TextBox>
                  </div>
                  <div class="form-group">
                      <label ID="saticisifrelbl" runat="server" style="color: #FFFFFF">Şifre</label>
                      <asp:TextBox ID="saticisifretxt" runat="server" CssClass="auto-style1" TextMode="Password" Width="290px"></asp:TextBox>
                  </div>
                  <div class="form-group">
                      <asp:Button ID="saticigirisbtn" runat="server" CssClass="btnSubmit" Text="Giriş" OnClick="saticigirisbtn_Click" />
                      <asp:Button ID="saticikayitbtn" runat="server" CssClass="btn btn-success" Text="Kayıt Ol" OnClick="saticikayitbtn_Click"/>
                  </div>
                  <div class="form-group">
                      <asp:Label ID="saticimesajlbl" runat="server" ForeColor="Aqua"></asp:Label>
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
    
    <script src="https://www.google-analytics.com/analytics.js" async></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>