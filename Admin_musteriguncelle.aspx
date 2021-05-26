<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_musteriguncelle.aspx.cs" Inherits="Istıhdam.Admin_musteriguncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center">Müşteri Profili Güncelle</h3>
    <table class="auto-style12" style="padding: 10px; margin: 50px auto auto auto; width:100%; text-align: center;">
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
                                <asp:TextBox ID="musteridogtartxt" runat="server" TextMode="DateTime" ValidationGroup="x"></asp:TextBox>
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
                                <asp:TextBox ID="musterisifretxt" runat="server" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="musterisifre" runat="server" ControlToValidate="musterisifretxt" ErrorMessage="Şifreyi Boş Geçmeyiniz">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şifreyi Tekrarlayınız:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="musterisifretekrartxt" runat="server" ValidationGroup="x"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="musterisifretekrartxt" ErrorMessage="Şifreyi boş geçmeyin">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="musterisifrekont" runat="server" ControlToCompare="musterisifretxt" ControlToValidate="musterisifretekrartxt" ErrorMessage="Şifre Aynı Değil">*</asp:CompareValidator>
                                <asp:CustomValidator ID="musterisifreksayi" runat="server" ErrorMessage="Şifre en az 6 karakter olmalı" OnServerValidate="musterisifreksayi_ServerValidate">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                
                                <asp:Button ID="guncellebtn" runat="server" CssClass="btn-primary" Text="Güncelle" ValidationGroup="x" OnClick="guncellebtn_Click" />
                                
                                <asp:Label ID="musterimesajlbl" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        </table>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="x" Width="225px" />
                    <br />
</asp:Content>
