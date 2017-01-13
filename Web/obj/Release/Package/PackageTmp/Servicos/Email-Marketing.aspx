<%@ Page Title="Poob Shop – Serviço de E-mail Marketing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Email-Marketing.aspx.cs" Inherits="Web.Servicos.Email_Marketing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnEnviar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Fieldset1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <telerik:RadWindowManager ID="RadWindowManager1" EnableShadow="true" Behaviors="Close" Localization-Close="Fechar" runat="server">
        <AlertTemplate>
            <div class="rwDialog rwAlertDialog">
                <div class="rwDialogContent">
                    <div class="rwDialogMessage">
                        <br />
                        {1}
                    </div>
                </div>
            </div>
        </AlertTemplate>
    </telerik:RadWindowManager>
    <fieldset id="Fieldset1" runat="server">
        <legend>E-mail Marketing</legend>
        Assunto (Insira {0} para tratar o cliente pelo nome)
        <br />
        <telerik:RadTextBox ID="txtAssunto" Width="100%" RenderMode="Auto" runat="server"></telerik:RadTextBox>
        <br />
        Mensagem (Insira {0} para tratar o cliente pelo nome)
        <br />
        <telerik:RadEditor ID="txtMensagem" Width="100%" RenderMode="Auto" Language="pt-BR" runat="server"></telerik:RadEditor>
        <br />
        <telerik:RadButton ID="btnEnviar" ButtonType="StandardButton" Text="Enviar" AutoPostBack="true" RenderMode="Auto" OnClick="btnEnviar_Click" runat="server"></telerik:RadButton>
    </fieldset>
</asp:Content>