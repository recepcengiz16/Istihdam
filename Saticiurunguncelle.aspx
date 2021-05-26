<%@ Page Title="" Language="C#" MasterPageFile="~/Satici.Master" AutoEventWireup="true" CodeBehind="Saticiurunguncelle.aspx.cs" Inherits="Istıhdam.Saticiurunguncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align:center">Ürün Güncelle</h3>
    <table style="margin: 50px auto auto auto; padding: 50px; width: 80%; text-align: center; height: 401px;border-style:solid">
        <tr>
            <td class="auto-style2" style="width: 140px; font-weight: bold; text-align: right;">Ürün Adı:</td>
            <td style="text-align: left; width: 364px;">
                <asp:TextBox ID="urunaditxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="width: 140px; font-weight: bold; text-align: right;">Fiyatı:</td>
            <td style="text-align: left; width: 364px;">
                <asp:TextBox ID="fiyattxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="width: 140px; font-weight: bold; text-align: right;">Açıklama:</td>
            <td style="text-align: left; width: 364px;">
                <asp:TextBox ID="aciklamatxt" runat="server" Height="118px" TextMode="MultiLine" Width="262px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="width: 140px; font-weight: bold; text-align: right;">Kategorisi:</td>
            <td style="text-align: left; width: 364px;">
                <asp:DropDownList ID="kategoridrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="kategoridrop_SelectedIndexChanged">
                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="width: 140px; font-weight: bold; text-align: right;">Alt Kategori Seçiniz:</td>
            <td style="text-align: left; width: 364px;">
                <asp:DropDownList ID="altkategoridrop" runat="server">
                    <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" style="width: 140px; font-weight: bold; text-align: right;">Resim Seçiniz:</td>
            <td style="text-align: left; width: 364px;">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="318px" />
                <asp:Image ID="Image1" runat="server" Height="110px" Width="120px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CssClass="btn-success" OnClick="Button1_Click" Text="Ürünü güncelle" />
                
                <asp:Label ID="mesajlbl" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
