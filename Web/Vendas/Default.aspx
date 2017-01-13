<%@ Page Title="Poob Shop – Vendas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Vendas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function clientFileUploaded(sender, args) {
            var count = sender._getRowCount();

            if (count > 2) {
                Array.removeAt(sender._uploadedFiles, 0);
                sender.deleteFileInputAt(0);
                sender.updateClientState();
            }
        }
    </script>
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
                    <telerik:AjaxUpdatedControl ControlID="rwUpload" />
                    <telerik:AjaxUpdatedControl ControlID="rwAttached" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rwSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rwSave" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rwUpload">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rwUpload" LoadingPanelID="RadAjaxLoadingPanel1" />
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
        <legend>Vendas</legend>
        <telerik:RadGrid ID="RadGrid1" GroupPanelPosition="Top" AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="10"
            AllowAutomaticInserts="false" AllowAutomaticUpdates="false" AllowAutomaticDeletes="true" ExportSettings-Excel-Format="Xlsx"
            RenderMode="Auto" Culture="pt-BR" DataSourceID="ObjectDataSource1" OnItemDataBound="RadGrid1_ItemDataBound" OnBatchEditCommand="RadGrid1_BatchEditCommand" runat="server">
            <MasterTableView Width="100%" DataKeyNames="Id" CommandItemDisplay="Top" EditMode="Batch" DataSourceID="ObjectDataSource1">
                <CommandItemSettings ShowAddNewRecordButton="false"></CommandItemSettings>
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Id" DataField="Id" UniqueName="Id"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Data de Cadastro" DataField="Cadastro" UniqueName="Cadastro"
                        HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="E-mail do Cliente" DataField="Email" UniqueName="Email"
                        HeaderStyle-Width="11%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Descrição do Produto" DataField="Descricao" UniqueName="Descricao"
                        HeaderStyle-Width="19%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Valor" DataField="Valor" UniqueName="Valor" DataFormatString="{0:c}"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Frete" DataField="Frete" UniqueName="Frete" DataFormatString="{0:c}"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Desconto" DataField="Desconto" UniqueName="Desconto" DataFormatString="{0:c}"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Total" DataField="Total" UniqueName="Total" DataFormatString="{0:c}"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="MercadoLivre" DataField="MercadoLivre" UniqueName="MercadoLivre"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("MercadoLivre") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadDropDownList ID="ddlMercadoLivre" Width="90px" DataTextField="MercadoLivre" RenderMode="Auto" runat="server">
                                <Items>
                                    <telerik:DropDownListItem Text="Não" Value="0" />
                                    <telerik:DropDownListItem Text="Sim" Value="1" />
                                </Items>
                            </telerik:RadDropDownList>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualificado" DataField="Qualificado" UniqueName="Qualificado"
                        HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("Qualificado") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadDropDownList ID="ddlQualificado" Width="90px" DataTextField="Qualificado" RenderMode="Auto" runat="server">
                                <Items>
                                    <telerik:DropDownListItem Text="Não" Value="0" />
                                    <telerik:DropDownListItem Text="Sim" Value="1" />
                                </Items>
                            </telerik:RadDropDownList>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Status da Venda" DataField="Status" UniqueName="Status"
                        HeaderStyle-Width="11%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# Eval("Status") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadDropDownList ID="ddlStatus" Width="190px" DataSourceID="dsStatus" DataValueField="Id" DataTextField="Descricao" RenderMode="Auto" runat="server"></telerik:RadDropDownList>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderImageUrl="~/Images/attach.png" UniqueName="AttachColumn"
                        HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAttach" ImageUrl="~/Images/attach.png" ToolTip="Anexar"
                                CommandArgument='<%# Eval("Id") %>' OnClick="btnAttach_Click" runat="server"></asp:ImageButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderImageUrl="~/Images/mail.png" UniqueName="MailColumn"
                        HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnMail" ImageUrl="~/Images/mail.png" ToolTip="Reenviar Notificação"
                                CommandArgument='<%# Eval("Id") %>' OnClick="btnMail_Click" runat="server"></asp:ImageButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" SelectMethod="SelectByAll" UpdateMethod="Update" DeleteMethod="Delete"
        TypeName="Library.DAL.VendaDAO" runat="server">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="idStatus" Type="Int32" />
            <asp:Parameter Name="valor" Type="Double" />
            <asp:Parameter Name="frete" Type="Double" />
            <asp:Parameter Name="desconto" Type="Double" />
            <asp:Parameter Name="mercadoLivre" Type="Boolean" />
            <asp:Parameter Name="qualificado" Type="Boolean" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsStatus" SelectMethod="SelectByStatus" TypeName="Library.DAL.VendaDAO" runat="server"></asp:ObjectDataSource>
    <telerik:RadWindow ID="rwSave" Title="Venda" Width="555" Height="530" Animation="Fade" EnableShadow="true"
        Behaviors="Minimize, Close, Move" Localization-Minimize="Minimizar" Localization-Close="Fechar" VisibleOnPageLoad="true" runat="server" Style="z-index: 1;">
        <ContentTemplate>
            <br />
            Nome Completo do Cliente
            <br />
            <telerik:RadAutoCompleteBox ID="txtNomeCompleto" InputType="Text" DataSourceID="dsCliente" DataTextField="NomeCompleto"
                TextSettings-SelectionMode="Single" AllowCustomEntry="true" Width="500px" RenderMode="Auto" runat="server">
            </telerik:RadAutoCompleteBox>
            <br />
            E-mail do Cliente
            <br />
            <telerik:RadAutoCompleteBox ID="txtEmail" InputType="Text" DataSourceID="dsCliente" DataTextField="Email"
                TextSettings-SelectionMode="Single" AllowCustomEntry="true" Width="500px" RenderMode="Auto" runat="server">
            </telerik:RadAutoCompleteBox>
            <asp:ObjectDataSource ID="dsCliente" SelectMethod="SelectByAll" TypeName="Library.DAL.ClienteDAO" runat="server"></asp:ObjectDataSource>
            <br />
            Descrição do Produto
            <br />
            <telerik:RadDropDownList ID="ddlProduto" DataSourceID="dsProduto" DataValueField="Id" DataTextField="Descricao" Width="443px" DropDownWidth="443px" DropDownHeight="185px"
                RenderMode="Auto" AutoPostBack="true" OnDataBound="ddlProduto_DataBound" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged" runat="server">
            </telerik:RadDropDownList>
            <asp:ObjectDataSource ID="dsProduto" SelectMethod="SelectByAll" TypeName="Library.DAL.ProdutoDAO" runat="server"></asp:ObjectDataSource>
            <telerik:RadNumericTextBox ID="txtQuantidade" Value="1" MinValue="1" MaxValue="100" MaxLength="3" NumberFormat-DecimalDigits="0" ShowSpinButtons="true" Width="52px" RenderMode="Auto" runat="server"></telerik:RadNumericTextBox>
            <br />
            Frete
            <br />
            <telerik:RadNumericTextBox ID="txtFrete" Value="0" MinValue="0" MaxLength="5" Type="Currency" Width="500px" RenderMode="Auto" runat="server"></telerik:RadNumericTextBox>
            <br />
            Desconto
            <br />
            <telerik:RadNumericTextBox ID="txtDesconto" MinValue="0" MaxLength="5" Type="Currency" Width="500px" RenderMode="Auto" runat="server"></telerik:RadNumericTextBox>
            <br />
            Status da Venda
            <br />
            <telerik:RadDropDownList ID="ddlStatus" DataSourceID="dsStatusId1e2" DataValueField="Id" DataTextField="Descricao" Width="500px" DropDownWidth="500px" RenderMode="Auto" runat="server"></telerik:RadDropDownList>
            <asp:ObjectDataSource ID="dsStatusId1e2" SelectMethod="SelectByStatusId1e2" TypeName="Library.DAL.VendaDAO" runat="server"></asp:ObjectDataSource>
            <br />
            <telerik:RadButton ID="chkMercadoLivre" ButtonType="ToggleButton" ToggleType="CheckBox" Checked="true" AutoPostBack="true" RenderMode="Auto" OnCheckedChanged="chkMercadoLivre_CheckedChanged" runat="server">
                <ToggleStates>
                    <telerik:RadButtonToggleState Text="Compra realizada pelo MercadoLivre." />
                </ToggleStates>
            </telerik:RadButton>
            <br />
            <telerik:RadButton ID="btnSave" ButtonType="StandardButton" Text="Salvar" AutoPostBack="true" RenderMode="Auto" OnClick="btnSave_Click" runat="server"></telerik:RadButton>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadWindow ID="rwUpload" Title="Upload" Width="350" Height="230" Animation="Fade" EnableShadow="true"
        Behaviors="Minimize, Close, Move" Localization-Minimize="Minimizar" Localization-Close="Fechar" runat="server" Style="z-index: 1;">
        <ContentTemplate>
            <br />
            <telerik:RadAsyncUpload ID="RadAsyncUpload1" AllowedFileExtensions="png" Localization-Select="Selecionar" Localization-Cancel="Cancelar"
                MaxFileSize="2097152" MaxFileInputsCount="1" Width="100%" RenderMode="Auto" OnClientFileUploaded="clientFileUploaded" runat="server">
            </telerik:RadAsyncUpload>
            <telerik:RadButton ID="btnUpload" ButtonType="StandardButton" Text="Upload" AutoPostBack="true" RenderMode="Auto" OnClick="btnUpload_Click" runat="server"></telerik:RadButton>
        </ContentTemplate>
    </telerik:RadWindow>
    <telerik:RadWindow ID="rwAttached" Title="Anexo" Width="335" Height="663" Animation="Fade" EnableShadow="true"
        Behaviors="Minimize, Close, Move" Localization-Minimize="Minimizar" Localization-Close="Fechar" runat="server" Style="z-index: 1;">
        <ContentTemplate>
            <br />
            <asp:Image ID="imgAttached" Width="300px" Height="533px" runat="server" />
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>