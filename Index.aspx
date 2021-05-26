<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Istıhdam.Index" %>

<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8"/>
        <title>Ana Sayfa</title>
        <meta name="viewport" content="width=device-width,initial-scale=1, shrink-to-fit=no"/>        
        <link rel="stylesheet" href="css/normalize.css">
        <link rel="stylesheet" href="css/main.css">
        <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/still.css" rel="stylesheet"/>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css"/>
        <style>
          .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
          }
    
          @media (min-width: 768px) {
            .bd-placeholder-img-lg {
              font-size: 3.5rem;
            }
          }
        </style> 
        <!-- Custom styles for this template -->
        <link href="carousel.css" rel="stylesheet">
    </head>
<body>
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
<main>

  <div id="myCarousel" class="carousel slide" data-bs-ride="carousel">
    <ol class="carousel-indicators">
      <li data-bs-target="#myCarousel" data-bs-slide-to="0" class="active"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="1"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="2"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="3"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="4"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="5"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="6"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="7"></li>
      <li data-bs-target="#myCarousel" data-bs-slide-to="8"></li>
    </ol>
    <div class="carousel-inner">
      <div class="carousel-item active">
          <img class="img-fluid" src="img/anasayfa1.jpg" width="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa2.jpg" width="100%" height="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa3.jpg" width="100%" height="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa4.jpg" width="100%" height="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa5.jpg" width="100%" height="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa6.jpg" width="100%" height="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa7.jpg" width="100%" height="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa8.jpg" width="100%" height="100%"/> 
      </div>
      <div class="carousel-item">
        <img class="img-fluid" src="img/anasayfa9.jpg" width="100%" height="100%"/> 
      </div>
    </div>
    <a class="carousel-control-prev" href="#myCarousel" role="button" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </a>
    <a class="carousel-control-next" href="#myCarousel" role="button" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </a>
  </div>
<p></p>
<p></p>
  <!-- Marketing messaging and featurettes
  ================================================== -->
  <!-- Wrap the rest of the page in another container to center all the content. -->

  <div class="container marketing">
    <h1 style="text-align: center;">Proje Destekçilerimiz</h1>
    <p></p>
    <p></p>
    <!-- Three columns of text below the carousel -->
    <div class="row">
      <div class="col-lg-4">
        <img src="img/bursalogo.png" class="rounded-circle" width="140" height="140"/>
        <p></p>
        <p></p>
        <h3>Bursa Büyükşehir Belediyesi</h3>
        <p>Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>
        <p><a class="btn btn-secondary" href="#" role="button">View details &raquo;</a></p>
      </div><!-- /.col-lg-4 -->
      <div class="col-lg-4">
        <img src="img/nilüferlogo.jpg" class="rounded-circle" width="200" height="140"/>
        <p></p>
        <p></p>
        <h3>Bursa/Nilüfer Belediyesi</h3>
        <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Cras mattis consectetur purus sit amet fermentum. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh.</p>
        <p><a class="btn btn-secondary" href="#" role="button">View details &raquo;</a></p>
      </div><!-- /.col-lg-4 -->
      <div class="col-lg-4">
        <img src="img/btso.jfif" class="rounded-circle" width="140" height="140"/>
        <p></p>
        <p></p>
        <h3>BUTGEM</h3>
        <p>Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
        <p><a class="btn btn-secondary" href="#" role="button">View details &raquo;</a></p>
      </div><!-- /.col-lg-4 -->
    </div><!-- /.row -->
</main> 
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
