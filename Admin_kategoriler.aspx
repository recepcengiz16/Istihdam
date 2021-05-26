<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_kategoriler.aspx.cs" Inherits="Istıhdam.Admin_kategoriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%; height: 203px;">
        <tr>
            <td style="text-align: center">
                <asp:Label ID="mesajlbl" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="text-align: center"></td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:RadioButton ID="kategoriradio" runat="server" AutoPostBack="True" GroupName="x" OnCheckedChanged="kategoriradio_CheckedChanged" Text="Kategori Ekle" />
            </td>
            <td style="text-align: center">
                <asp:RadioButton ID="altkategoriradio" runat="server" AutoPostBack="True" GroupName="x" OnCheckedChanged="altkategoriradio_CheckedChanged" Text="Alt Kategori Ekle" />
            </td>
            <td style="text-align: center">
                <asp:RadioButton ID="tumkatelisteleradio" runat="server" Text="Kategorileri Göster" AutoPostBack="True" GroupName="x" OnCheckedChanged="tumkatelisteleradio_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Panel ID="Panel1" runat="server" Height="57px" Visible="False">
                    <asp:Label ID="kateeklelbl" runat="server" Text="Kategori Adını Giriniz:"></asp:Label>
                    <asp:TextBox ID="kateaditxt" runat="server"></asp:TextBox>
                    <asp:Button ID="kateeklebtn" runat="server" CssClass="btn btn-success" OnClick="kateeklebtn_Click" Text="Ekle" Width="47px" />
                </asp:Panel>
            </td>
            <td style="text-align: center">
                <asp:Panel ID="Panel2" runat="server" Height="116px" Visible="False">
                    <asp:Label ID="hangikatelbl" runat="server" Text="Hangi Kategori Seçiniz:"></asp:Label>
                    <asp:DropDownList ID="altkateanasecimdrop" runat="server">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="altkatedilbl" runat="server" Text="Alt Kategori Adı Giriniz:"></asp:Label>
                    <asp:TextBox ID="altkateaditxt" runat="server"></asp:TextBox>
                    <asp:Button ID="altkateeklebtn" runat="server" CssClass="btn btn-success" OnClick="altkateeklebtn_Click" Text="Ekle" Width="49px" />
                </asp:Panel>
            </td>
            <td style="text-align: center">
                <asp:Panel ID="Panel3" runat="server" Height="114px" Visible="False">
                    <asp:Label ID="anakatelbl" runat="server" Text="Ana Kategori:"></asp:Label>
                    <asp:DropDownList ID="anakatedrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="anakatedrop_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="altkatelbl" runat="server" Text="Alt Kategori:"></asp:Label>
                    <asp:DropDownList ID="altkatedrop" runat="server">
                        <asp:ListItem Value="0">Seçiniz</asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
            </td>
        </tr>
        </table>
</asp:Content>
