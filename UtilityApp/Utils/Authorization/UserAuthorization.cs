using System;
using System.Web;
using System.Web.Mvc;

namespace Utils.Authorization
{
    /// <summary>
    /// Class UserAuthorization.
    /// </summary>
    public class UserAuthorization : AuthorizeAttribute
    {
        /// <summary>
        /// redirectTo. Default /user/login
        /// </summary>
        public string RedirectTo = "~/User/Login";

        /// <summary>
        /// AuthorizeCore
        /// </summary>
        /// <param name="httpContext">HttpContextBase</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

        //    if (httpContext.Session != null && httpContext.Session["UserLogin"] == null)
        //    {
        //        Setredirectpath(httpContext);
        //        return false;
        //    }
        //    var user = (UserLoginModel)httpContext.Session?["UserLogin"];
        //    if (user?.UserID != null && user?.UserName.Length > 0)
        //    {
        //        Setredirectpath(httpContext);
        //        return false;
        //    }
        //    return true;
        //}

        /// <summary>
        /// Sets the redirection path
        /// </summary>
        /// <param name="httpContext">HttpContextBase</param>
        public void Setredirectpath(HttpContextBase httpContext)
        {
            if (!string.IsNullOrEmpty(httpContext.Request.RawUrl))
            {
                RedirectTo = string.Format(RedirectTo + "?returnUrl={0}",
                    HttpUtility.UrlEncode(httpContext.Request.RawUrl));
            }
        }

        /// <summary>
        /// OnAuthorization
        /// </summary>
        /// <param name="filterContext">AuthorizationContext</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //If authorization results in HttpUnauthorizedResult, redirect to error page instead of Logon page.
            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.Result = new RedirectResult(RedirectTo);
        }
    }
}
