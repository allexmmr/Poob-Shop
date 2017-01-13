using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            FormsAuthentication.RedirectFromLoginPage("shop@poob.com.br", true);
#endif
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if ((Login1.UserName == "shop@poob.com.br") && (Login1.Password == "p@2008info"))
            {
                e.Authenticated = true;

                //Verifica se o usuário retornou da página de Logout
                if (HttpContext.Current.Request.Url.PathAndQuery.Contains("Logout"))
                {
                    FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);
                    Response.Redirect("~/Vendas/");
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                }
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}