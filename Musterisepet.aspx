<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Musterisepet.aspx.cs" Inherits="Istıhdam.Deneme" %>

<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8"/>
        <title>Müşteri Panel</title>
        <meta name="viewport" content="width=device-width,initial-scale=1, shrink-to-fit=no"/>        
        <link rel="stylesheet" href="css/normalize.css">
        <link rel="stylesheet" href="css/main.css">
        <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/still.css" rel="stylesheet"/>
        <link href="css/dashboard.css" rel="stylesheet"/>
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
            .auto-style1 {
                width: 100%;
                height: 574px;
            }
            .auto-style2 {
                width: 222px;
            }
            .auto-style3 {
                width: 100%;
                padding-right: var(--bs-gutter-x,.75rem);
                padding-left: var(--bs-gutter-x,.75rem);
                margin-right: auto;
                margin-left: auto;
                height: 577px;
            }
            .auto-style4 {
                height: 576px;
            }
          </style>
    </head>
<body style="height: 50px">
    <form id="form1" runat="server">
    <header class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
        <a class="navbar-brand col-md-3 col-lg-2 me-0 px-3" style="font-weight: bold;">Bir destek de benden</a>
        <button class="navbar-toggler position-absolute d-md-none collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
         <ul class="navbar-nav px-3">
          <li class="nav-item text-nowrap">
            <asp:LinkButton ID="cikisbtn" runat="server" OnClick="cikisbtn_Click">Çıkış Yap</asp:LinkButton>
          </li>
        </ul>
      </header>
          <div class="auto-style3">
              <table class="auto-style1">
                  <tr>
                      <td class="auto-style2">
                          <div class="auto-style4" style="text-align: center;background-color:#333333">
                              
                              <br />
                              <br />
                              <asp:HyperLink ID="profilbilgi" runat="server" ForeColor="White" Font-Size="Large" NavigateUrl="~/Musteriprofil.aspx"><span data-feather="users"></span> Profil Bilgilerim</asp:HyperLink>
                              <br />
                              <br />                             
                              <asp:HyperLink ID="siparis" runat="server" Font-Size="Large" ForeColor="White" NavigateUrl="~/Musterisiparis.aspx"><span data-feather="shopping-cart"></span> Siparişlerim</asp:HyperLink>
                              <br />
                              <br />
                              <asp:HyperLink ID="Urunler" runat="server" Font-Size="Large" ForeColor="White" NavigateUrl="~/Urunler.aspx"><span data-feather="file"></span> Ürünler</asp:HyperLink>
                              <br />
                              <br />
                              <asp:HyperLink ID="rapor" runat="server" Font-Size="Large" ForeColor="White"><span data-feather="bar-chart-2"></span> Raporlar</asp:HyperLink>
                              
                          </div>
                      </td>
                      <td>
                          <table style="width:100%;">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Table ID="Table1" runat="server" CssClass="table" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" Font-Bold="True">Ürün Adı</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="True">Fiyatı(TL)</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="True">Kategorisi</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="True">Alt Kategorisi</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="True">Adet</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="True">Resim</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="True">Sil</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="yenilebtn" runat="server" CssClass="btn-danger" OnClick="yenilebtn_Click" Text="Sepeti Yenile" />
            </td>
            <td style="text-align: center">
                <asp:Button ID="satinalbtn" runat="server" CssClass="btn-success" OnClick="satinalbtn_Click" Text="Satın Al" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="toplamlbl" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="siparislbl" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
                      </td>
                  </tr>
              </table>
          </div>  
            <script src="js/bootstrap.bundle.min.js"></script>
            <script src="https://cdn.jsdelivr.net/npm/feather-icons@4.28.0/dist/feather.min.js" integrity="sha384-uO3SXW5IuS1ZpFPKugNNWqTZRRglnUJK6UAZ/gxOX80nxEkN9NcGZTftn6RzhGWE" crossorigin="anonymous"></script><script src="https://cdn.jsdelivr.net/npm/chart.js@2.9.4/dist/Chart.min.js" integrity="sha384-zNy6FEbO50N+Cg5wap8IKA4M/ZnLJgzc6w2NqACZaK0u0FXfOWRRJOnQtpZun8ha" crossorigin="anonymous"></script>
            <script src="js/dashboard.js"></script>

    </form>

</body>
</html>