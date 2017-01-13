using System;

namespace Web.Relatorios
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.ServerReport.ReportPath = "~/Content/Reports/ClientesReport.rdlc";
        }
    }
}