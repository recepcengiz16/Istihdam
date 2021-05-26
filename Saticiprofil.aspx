<%@ Page Title="" Language="C#" MasterPageFile="~/Satici.Master" AutoEventWireup="true" CodeBehind="Saticiprofil.aspx.cs" Inherits="Istıhdam.Saticiprofil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3 style="text-align: center">Profil Bilgilerim</h3>
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
                <asp:RegularExpressionValidator ID="saticiemailformat" runat="server" ControlToValidate="saticiemailtxt" ErrorMessage="E mail formatını doğru giriniz." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
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
                <asp:TextBox ID="saticidogtartxt" runat="server" ValidationGroup="y"></asp:TextBox>
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
                <asp:TextBox ID="saticisifretxt" runat="server" ValidationGroup="y"></asp:TextBox>
                <asp:RequiredFieldValidator ID="saticisifre" runat="server" ControlToValidate="saticisifretxt" ErrorMessage="Şifre boş geçilemez">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style11" style="text-align: right; font-weight: bold;">Şifreyi Tekrarlayınız:</td>
            <td style="text-align: left">
                <asp:TextBox ID="saticisifretekrartxt" runat="server" ValidationGroup="y"></asp:TextBox>
                <asp:RequiredFieldValidator ID="saticisifretekrar" runat="server" ControlToValidate="saticisifretekrartxt" ErrorMessage="Sifre tekrar boş geçilemez">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="saticisifrekarsil" runat="server" ControlToCompare="saticisifretekrartxt" ControlToValidate="saticisifretxt" ErrorMessage="Şifreler aynı değil">*</asp:CompareValidator>
                <asp:CustomValidator ID="saticisifrek" runat="server" ErrorMessage="Şifre en az 6 karakterli olmalı" OnServerValidate="saticisifrek_ServerValidate">*</asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="guncellebtn" runat="server" CssClass="btn-success" Text="Güncelle" ValidationGroup="y" OnClick="guncellebtn_Click" />
                <asp:Label ID="saticimesajlbl" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        </table>
    <br />
<asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="229px" ShowMessageBox="True" ShowSummary="False" />
    <br />
</asp:Content>
