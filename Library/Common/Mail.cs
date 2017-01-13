using System.Net.Mail;

namespace Library.Common
{
    public class Mail
    {
        #region Propriedades

        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        #endregion

        #region SendMail

        /// <summary>
        /// Envio de e-mail
        /// </summary>
        public void SendMail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            mail.From = new MailAddress(SenderMail, SenderName, System.Text.Encoding.UTF8);
            mail.To.Add(Recipient);
            mail.Subject = Subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = Message;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            smtp.Credentials = new System.Net.NetworkCredential(SenderMail, "p@2008info");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        #endregion
    }
}