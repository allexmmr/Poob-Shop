<%@ Page Title="Poob Shop – Relatório de Vendas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendas.aspx.cs" Inherits="Web.Relatorios.Vendas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Relatório de Vendas</legend>
        <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"></rsweb:ReportViewer>
    </fieldset>
</asp:Content>