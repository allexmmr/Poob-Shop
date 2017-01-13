using System;

namespace Web.Relatorios
{
    public partial class Vendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.ServerReport.ReportPath = "~/Content/Reports/VendasReport.rdlc";
        }
    }
}