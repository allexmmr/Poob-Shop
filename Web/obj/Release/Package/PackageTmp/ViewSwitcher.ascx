<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSwitcher.ascx.cs" Inherits="Web.ViewSwitcher" %>
<div id="viewSwitcher">
    Versão <%: CurrentView %> | <a href="<%: SwitchUrl %>" title="Trocar para <%: AlternateView %>" data-ajax="false" >Trocar para <%: AlternateView %></a>
</div>