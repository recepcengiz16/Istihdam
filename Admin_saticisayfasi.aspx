<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_saticisayfasi.aspx.cs" Inherits="Istıhdam.Admin_saticisayfasi" %>
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
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Adı</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Soyadı</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Kullanıcı Adı</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Şifre</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı E mail</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Telefon</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Adres</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Şehir</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Satıcı Doğum Tarihi</asp:TableCell>
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
