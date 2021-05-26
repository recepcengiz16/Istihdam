<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="Istıhdam.Urunlerim" %>

<!DOCTYPE html>

<html>
    <head runat="server">
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
            .auto-style1 {
                width: 297px;
            }
            .auto-style2 {
                width: 100%;
                height: 1008px;
            }
            .auto-style4 {
                height: 797px;
                margin-left: 0px;
            }
            .auto-style11 {
                height: 778px;
                margin-right: 12px;
            }
        </style> 
        <!-- Custom styles for this template -->
        <link href="carousel.css" rel="stylesheet">
    </head>
<body style="height: 151px">
  <!--HEADER KISMI-->
<form runat="server">
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
            <a class="nav-link active" href="Urunler.aspx">Ürünlerimiz</a>
          </li>
        </ul>
          <ul class="nav navbar-nav navbar-right">
            <li>
                <asp:HyperLink ID="uyegitlink" runat="server" Text="Üye kayıt sayfasına git" Visible="False" NavigateUrl="~/Uyegiris.aspx"></asp:HyperLink>
                <asp:Button ID="Sepetimbtn" runat="server" Text="Sepetim" CssClass="btn btn-danger" Visible="False" PostBackUrl="~/Musterisepet.aspx" />

            &nbsp;</li>
              <li>
                  <asp:Button ID="Sayfamadon" runat="server" Text="Sayfama Dön" CssClass="btn btn-success" Visible="False" PostBackUrl="~/Musteriprofil.aspx" />
              </li>
          </ul>
      </div>
    </div>
  </nav>
</div>
    
        <div>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style1">
                        <div class="auto-style11" style="text-align: center">
                            
                            <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium" ForeColor="#7C6F57" Height="255px" StaticSubMenuIndent="10px" Width="50%">
                                <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                                <DynamicMenuStyle BackColor="#F7F6F3" />
                                <DynamicSelectedStyle BackColor="#5D7B9D" />
                                <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                                <StaticSelectedStyle BackColor="#5D7B9D" />
                            </asp:Menu>
                            
                        </div>
                    </td>
                    <td>
                        <div class="auto-style4" style="text-align: center">
                            
                            <asp:Table ID="Table1" runat="server" Height="95%" Width="100%">
                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server"></asp:TableCell>
                                    <asp:TableCell runat="server"></asp:TableCell>
                                    <asp:TableCell runat="server"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server"></asp:TableCell>
                                    <asp:TableCell runat="server"></asp:TableCell>
                                    <asp:TableCell runat="server"></asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server"></asp:TableCell>
                                    <asp:TableCell runat="server"></asp:TableCell>
                                    <asp:TableCell runat="server"></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <br />
                            <br />
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="sayfalbl" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
