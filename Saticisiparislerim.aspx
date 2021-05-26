<%@ Page Title="" Language="C#" MasterPageFile="~/Satici.Master" AutoEventWireup="true" CodeBehind="Saticisiparislerim.aspx.cs" Inherits="Istıhdam.Saticisiparislerim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
    <tr>
        <td>
            <asp:Table ID="Table1" runat="server" CssClass="table">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Font-Bold="True">Sipariş Tarihi</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Ad Soyad</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri E mail</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Müşteri Adresi</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Ürün Adı</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Adet</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Resim</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Ödeme Miktarı(TL)</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="sayfalalbl" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
