<%@ Page Title="" Language="C#" MasterPageFile="~/Satici.Master" AutoEventWireup="true" CodeBehind="Saticiurunlerim.aspx.cs" Inherits="Istıhdam.Saticiurunlerim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    
    <table style="width:100%;">
        <tr>
            <td style="text-align: center">
                <asp:Label ID="mesajlbl" runat="server"></asp:Label>
            </td>
            <td style="text-align: center">
                &nbsp;</td>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Ana Kategori:"></asp:Label>
                <asp:DropDownList ID="anakategoridrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="anakategoridrop_SelectedIndexChanged">
                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Alt Kategori:"></asp:Label>
                <asp:DropDownList ID="altkatedrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="altkatedrop_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: center">
                <asp:RadioButton ID="tumuradiobtn" runat="server" Font-Bold="True" Text="Tümü" AutoPostBack="True" OnCheckedChanged="tumuradiobtn_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Table ID="Table1" runat="server" CssClass="table" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" BorderStyle="Solid" Font-Bold="True">Ürün Adı</asp:TableCell>
                        <asp:TableCell runat="server" BorderStyle="Solid" Font-Bold="True">Fiyatı</asp:TableCell>
                        <asp:TableCell runat="server" BorderStyle="Solid" Font-Bold="True">Açıklama</asp:TableCell>
                        <asp:TableCell runat="server" BorderStyle="Solid" Font-Bold="True">Kategorisi</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="True">Alt Kategorisi</asp:TableCell>
                        <asp:TableCell runat="server" BorderStyle="Solid" Font-Bold="True">Resim</asp:TableCell>
                        <asp:TableCell runat="server" BorderStyle="Solid" Font-Bold="True">Güncelle</asp:TableCell>
                        <asp:TableCell runat="server" BorderStyle="Solid" Font-Bold="True">Sil</asp:TableCell>
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
