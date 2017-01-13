<%@ Page Title="Poob Shop – Erro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Erro.aspx.cs" Inherits="Web.Erro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error">
        <asp:Image ID="imgErro" ImageUrl="~/Images/erro.png" AlternateText="Erro 404" runat="server" />
        <div class="errorCol">
            <h2>Causas mais prováveis:</h2>
            Você digitou o endereço errado;
            <br />
            O conteúdo não está mais no ar;
            <br />
            A página mudou de lugar.
        </div>
        <div class="errorCol">
            <h2>Vá para o site da Poob Shop:</h2>
            <asp:HyperLink ID="lnkPoobShop" NavigateUrl="~/Default" ImageUrl="~/Images/logo-poob-shop.png" ToolTip="Poob Shop" runat="server" />
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>