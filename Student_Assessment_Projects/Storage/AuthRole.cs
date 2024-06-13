using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Student_Assessment_Projects.Storage
{
    public class AuthRole : AuthorizeAttribute
    {
        private readonly string[] _roles;

        public AuthRole(params string[] roles)
        {
            _roles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userRole = httpContext.Session["Role"]?.ToString();

            if (string.IsNullOrEmpty(userRole) ) 
            {
                return false;
            }

            return _roles.Contains(userRole);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Account", action = "Login" }));
        }

    }
}
