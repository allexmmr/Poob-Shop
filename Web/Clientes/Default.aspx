﻿<%@ Page Title="Poob Shop – Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Clientes.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadFilter1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadFilter1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <fieldset>
        <legend>Filtrar</legend>
        <telerik:RadFilter ID="RadFilter1" FilterContainerID="RadGrid1" Culture="pt-BR" runat="server"></telerik:RadFilter>
    </fieldset>
    <fieldset>
        <legend>Exportar</legend>
        <telerik:RadButton ID="btnExportarParaExcel" Image-ImageUrl="~/Images/excel.png" Width="23" Height="32" BorderWidth="0" ToolTip="Exportar para Excel" RenderMode="Auto" Skin="Default" OnClick="btnExportarParaExcel_Click" runat="server"></telerik:RadButton>
        <telerik:RadButton ID="btnExportarParaPDF" Image-ImageUrl="~/Images/pdf.png" Width="23" Height="32" BorderWidth="0" ToolTip="Exportar para PDF" RenderMode="Auto" Skin="Default" OnClick="btnExportarParaPDF_Click" runat="server"></telerik:RadButton>
    </fieldset>
    <fieldset>
        <legend>Clientes</legend>
        <telerik:RadGrid ID="RadGrid1" GroupPanelPosition="Top" AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="10"
            AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowAutomaticDeletes="true" ExportSettings-Excel-Format="Xlsx"
            RenderMode="Auto" Culture="pt-BR" DataSourceID="ObjectDataSource1" runat="server">
            <MasterTableView Width="100%" DataKeyNames="Id" CommandItemDisplay="Top" EditMode="Batch" DataSourceID="ObjectDataSource1">
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Id" DataField="Id" UniqueName="Id"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Data de Cadastro" DataField="Cadastro" UniqueName="Cadastro"
                        HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Nome Completo do Cliente" DataField="NomeCompleto" UniqueName="NomeCompleto"
                        HeaderStyle-Width="27%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="E-mail do Cliente" DataField="Email" UniqueName="Email"
                        HeaderStyle-Width="28%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Qtde. Comprada" DataField="Quantidade" UniqueName="Quantidade"
                        HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn HeaderText="Alterar" Text="Alterar" CommandName="Edit" UniqueName="EditColumn"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ButtonType="ImageButton">
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn HeaderText="Excluir" Text="Excluir" CommandName="Delete" UniqueName="DeleteColumn"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ButtonType="ImageButton">
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </fieldset>
    <asp:ObjectDataSource ID="ObjectDataSource1" SelectMethod="SelectByAll" InsertMethod="Insert" UpdateMethod="Update" DeleteMethod="Delete"
        TypeName="Library.DAL.ClienteDAO" runat="server">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="nomeCompleto" Type="String" />
            <asp:Parameter Name="email" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="nomeCompleto" Type="String" />
            <asp:Parameter Name="email" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>