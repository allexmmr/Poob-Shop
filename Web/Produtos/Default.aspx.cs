using System;

namespace Web.Produtos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region btnExportarParaExcel_Click

        protected void btnExportarParaExcel_Click(object sender, EventArgs e)
        {
            // Oculta as colunas de edição e exclusão
            RadGrid1.MasterTableView.GetColumn("EditColumn").Visible = false;
            RadGrid1.MasterTableView.GetColumn("DeleteColumn").Visible = false;

            // Configura a exportação
            RadGrid1.ExportSettings.FileName = "Produtos";
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;

            // Exporta para Excel
            RadGrid1.MasterTableView.ExportToExcel();
        }

        #endregion

        #region btnExportarParaPDF_Click

        protected void btnExportarParaPDF_Click(object sender, EventArgs e)
        {
            // Oculta as colunas de edição e exclusão
            RadGrid1.MasterTableView.GetColumn("EditColumn").Visible = false;
            RadGrid1.MasterTableView.GetColumn("DeleteColumn").Visible = false;

            // Configura a exportação
            RadGrid1.ExportSettings.FileName = "Produtos";
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = true;
            RadGrid1.ExportSettings.OpenInNewWindow = true;

            // Exporta para PDF
            RadGrid1.MasterTableView.ExportToPdf();
        }

        #endregion
    }
}