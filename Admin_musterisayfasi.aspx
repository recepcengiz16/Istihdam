<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_musterisayfasi.aspx.cs" Inherits="Istıhdam.Admin_musterisayfasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="mesajlbl" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
            <asp:Table ID="Table1" runat="server" CssClass="table">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Ad Soyad</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Kullanıcı Adı</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Şifre</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri E mail</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Telefon</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Adres</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Şehir</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Doğum Tarihi</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Güncelle</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Sil</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="sayfalalbl" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
