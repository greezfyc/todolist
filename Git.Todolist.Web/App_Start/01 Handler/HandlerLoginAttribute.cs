using System.Web.Mvc;
using Git.Todolist.Core;

namespace Git.Todolist.Web
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;

        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                WebHelper.WriteCookie("todolist_login_error", "overdue");
             //   filterContext.HttpContext.Response.Write("<script>top.location.href = '/System/Log/Index';</script>");
                return;
            }
        }
    }
}