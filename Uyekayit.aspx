<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uyekayit.aspx.cs" Inherits="Istıhdam.Uyekayit" %>

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
            .auto-style5 {
                height: 26px;
            }
            .auto-style10 {
                height: 26px;
                width: 344px;
            }
            .auto-style11 {
                width: 344px;
            }
            .auto-style12 {
                width: 65%;
            }
        </style>
        </head>
<body style="height: 157px">
    <form runat="server">
  <!--HEADER KISMI-->
  <div class="header">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container-fluid">
        <a class="navbar-brand" href="index.aspx">Bir destek de benden</a>
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
        <div>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table class="auto-style12" style="padding: 50px; margin: 50px auto auto auto; width:65%; text-align: center;">
                        <tr>
                            <td class="auto-style10" style="text-align: right; font-weight: bold;">Ad Soyad:</td>
                            <td class="auto-style5" style="text-align: left">
                                <asp:TextBox ID="musteriadsoyadtxt" runat="server" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musteriad" runat="server" ControlToValidate="musteriadsoyadtxt" ErrorMessage="Ad Soyadı boş geçmeyiniz.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">E mail:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musteriemailtxt" runat="server" TextMode="Email" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musteriemail" runat="server" ControlToValidate="musteriemailtxt" ErrorMessage="E maili boş geçmeyiniz">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="musteriemailii" runat="server" ControlToValidate="musteriemailtxt" ErrorMessage="E maili doğru biçimde giriniz" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Telefon:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musteriteltxt" runat="server" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musteritel" runat="server" ControlToValidate="musteriteltxt" ErrorMessage="Telefon numarasını giriniz.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şehir:</td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="musterisehirdrop" runat="server" ValidationGroup="x">
                                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="musterisehir" runat="server" ControlToValidate="musterisehirdrop" ErrorMessage="Şehri seçiniz." InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Doğum Tarihi:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musteridogtartxt" runat="server" TextMode="Date" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musteridogrtar" runat="server" ControlToValidate="musteridogtartxt" ErrorMessage="Doğum Tarihini Seçiniz">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Adres:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musteriadrestxt" runat="server" Height="90px" TextMode="MultiLine" Width="220px" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musteriadres" runat="server" ControlToValidate="musteriadrestxt" ErrorMessage="Adres giriniz.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Kullanıcı Adı:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musterikuladitxt" runat="server" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musterikuladi" runat="server" ErrorMessage="Kullanıcı Adı Giriniz" ControlToValidate="musterikuladitxt">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şifre:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musterisifretxt" runat="server" TextMode="Password" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musterisifre" runat="server" ControlToValidate="musterisifretxt" ErrorMessage="Şifreyi Boş Geçmeyiniz">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şifreyi Tekrarlayınız:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musterisifretekrartxt" runat="server" TextMode="Password" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="musterisifretekrartxt" ErrorMessage="Şifreyi boş geçmeyin">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="musterisifrekont" runat="server" ControlToCompare="musterisifretxt" ControlToValidate="musterisifretekrartxt" ErrorMessage="Şifre Aynı Değil">*</asp:CompareValidator>
                                <asp:CustomValidator ID="musterisifreksayi" runat="server" ErrorMessage="Şifre en az 6 karakter olmalı" OnServerValidate="musterisifreksayi_ServerValidate">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="musterikaydetbtn" runat="server" CssClass="btn-primary" OnClick="musterikaydetbtn_Click" Text="Kaydet" ValidationGroup="x" />
                                <asp:Label ID="musterimesajlbl" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HyperLink ID="musterilink" runat="server" ForeColor="#0066CC" NavigateUrl="~/Uyegiris.aspx" Visible="False">Sisteme girebilmek için giriş yapınız.</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="x" Width="225px" />
                    <br />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table style="padding: 50px; margin: 50px auto auto auto; width:65%; text-align: center;">
                        <tr>
                            <td class="auto-style10" style="text-align: right; font-weight: bold;">Ad:</td>
                            <td class="auto-style5" style="text-align: left">
                                <asp:TextBox ID="saticiadtxt" runat="server" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticiad" runat="server" ControlToValidate="saticiadtxt" ErrorMessage="Ad ksımı boş geçilmez">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style10" style="text-align: right; font-weight: bold;">Soyad:</td>
                            <td class="auto-style5" style="text-align: left">
                                <asp:TextBox ID="saticisoyadtxt" runat="server" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticisoyad" runat="server" ControlToValidate="saticisoyadtxt" ErrorMessage="Satıcı soyadı boş geçilemez">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">E mail:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="saticiemailtxt" runat="server" TextMode="Email" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticiemail" runat="server" ControlToValidate="saticiemailtxt" ErrorMessage="E mail kısmı boş geçilmez">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="saticiemailformat" runat="server" ControlToValidate="musteriemailtxt" ErrorMessage="E mail formatını doğru giriniz.">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Telefon:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="saticiteltxt" runat="server" TextMode="Phone" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticitel" runat="server" ControlToValidate="saticiteltxt" ErrorMessage="Telefon nosunu giriniz.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şehir:</td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="saticisehirdrop" runat="server" ValidationGroup="y">
                                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="saticisehir" runat="server" ControlToValidate="saticisehirdrop" ErrorMessage="Lütfen şehir seçiniz" InitialValue="0">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Doğum Tarihi:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="saticidogtartxt" runat="server" TextMode="Date" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticidogtar" runat="server" ControlToValidate="saticidogtartxt" ErrorMessage="Lütfen doğum tarihini giriniz.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Adres:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="saticiadrestxt" runat="server" Height="90px" TextMode="MultiLine" Width="220px" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticiadres" runat="server" ControlToValidate="saticiadrestxt" ErrorMessage="Lütfen adresi giriniz.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Kullanıcı Adı:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="saticikuladitxt" runat="server" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticikuladi" runat="server" ControlToValidate="saticikuladitxt" ErrorMessage="Lütfen kullanıcı adı giriniz.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şifre:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="saticisifretxt" runat="server" TextMode="Password" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticisifre" runat="server" ControlToValidate="saticisifretxt" ErrorMessage="Şifre boş geçilemez">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şifreyi Tekrarlayınız:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="saticisifretekrartxt" runat="server" TextMode="Password" ValidationGroup="y"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="saticisifretekrar" runat="server" ControlToValidate="saticisifretekrartxt" ErrorMessage="Sifre tekrar boş geçilemez">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="saticisifrekarsil" runat="server" ControlToCompare="musterisifretekrartxt" ControlToValidate="musterisifretxt" ErrorMessage="Şifreler aynı değil">*</asp:CompareValidator>
                                <asp:CustomValidator ID="saticisifrek" runat="server" ErrorMessage="Şifre en az 6 karakterli olmalı" OnServerValidate="saticisifrek_ServerValidate">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="saticikaydetbtn" runat="server" CssClass="btn-success" OnClick="saticikaydetbtn_Click" Text="Kaydet" ValidationGroup="y" />
                                <asp:Label ID="saticimesajlbl" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:HyperLink ID="saticilink" runat="server" ForeColor="#0066CC" NavigateUrl="~/Uyegiris.aspx" Visible="False">Sisteme girebilmek için giriş yapınız.</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="y" Width="271px" />
                </asp:View>
            </asp:MultiView>
        </div>
</form>
</body>
</html>
