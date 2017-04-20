using rsi.Ui.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rsi.Ui
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        ///// <summary>
        ///// esse método é executado automáticamente quando um erro acontece
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError(); // obtém o erro detectado

        //    String url;
            
        //    if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
        //    {
        //        url = "~/PaginaInicial/Erro404?url=" + Request.Url.AbsoluteUri + "?ex="+ex;
        //        //EmailUtil.EnviarEmailErro("Erro 404 - Página não encontrada", "Usuário ou sistema tentou acessar página     inexistente:" + Request.Url.AbsoluteUri);
        //    }
        //    else
        //    {
        //        url = "~/Accounts/Index?ex=" + ex;
        //        //EmailUtil.EnviarEmailErro(ex);
        //    }

        //    this.Response.RedirectPermanent(url); // Encaminha a requisição para a página de erro adequada.
        //}
    }
}
