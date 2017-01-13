using Library.BLL;
using Library.Common;
using System;
using System.Data;
using System.Threading;

namespace Web.Servicos
{
    public partial class Email_Marketing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region btnEnviar_Click

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            #region Envia e-mail ao usuário

            try
            {
                // Recebe os dados do cliente
                ClienteBO cliente = new ClienteBO();
                DataTable dtCliente = cliente.SelectByAll();

                Mail mail = new Mail();

                for (int i = 0; i < dtCliente.Rows.Count; i++)
                {
                    mail.SenderName = "Poob Shop";
                    mail.SenderMail = "shop@poob.com.br";
                    mail.Recipient = dtCliente.Rows[i]["Email"].ToString();
                    mail.Subject = txtAssunto.Text.Contains("{0}") ? string.Format(txtAssunto.Text, dtCliente.Rows[i]["NomeCompleto"].ToString().Substring(0, dtCliente.Rows[i]["NomeCompleto"].ToString().IndexOf(" "))) : txtAssunto.Text;
                    mail.Message = txtMensagem.Content.Contains("{0}") ? string.Format(txtMensagem.Content, dtCliente.Rows[i]["NomeCompleto"].ToString().Substring(0, dtCliente.Rows[i]["NomeCompleto"].ToString().IndexOf(" "))) : txtMensagem.Content;

                    mail.SendMail();

                    // Espera 5 segundos
                    Thread.Sleep(5000);
                }

                // Limpa os campos após enviar o e-mail
                txtAssunto.Text = string.Empty;
                txtMensagem.Content = string.Empty;
            }
            catch (Exception ex)
            {
                RadWindowManager1.RadAlert("Erro: " + ex.Message, 300, 150, "Erro", null);
            }

            #endregion
        }

        #endregion
    }
}