<%@ Page Title="" Language="C#" MasterPageFile="~/Musteri.Master" AutoEventWireup="true" CodeBehind="Musterisiparis.aspx.cs" Inherits="Istıhdam.Musterisiparis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
    <tr>
        <td colspan="3" style="text-align: center">
            <asp:Table ID="Table1" runat="server" Width="100%">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Font-Bold="True">Sipariş No</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Ürün Adı</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Adet</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Fiyatı(TL)</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Resim</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Sipariş Tarihi</asp:TableCell>
                    <asp:TableCell runat="server" Font-Bold="True">Sipariş Durumu</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </td>
    </tr>
    <tr>
        <td class="auto-style2" style="text-align: center; width: 292px;">&nbsp;</td>
        <td style="text-align: center; width: 316px;">
            <asp:Label ID="sayfalalbl" runat="server"></asp:Label>
        </td>
        <td style="text-align: center">&nbsp;</td>
    </tr>
</table>
</asp:Content>
