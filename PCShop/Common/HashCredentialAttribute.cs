using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Common
{
    public class HashCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (Common.UserLogin)HttpContext.Current.Session[Common.CommonContants.USER_SESSION];
            if (session == null)
            {
                return false;
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.pk); // Call another method to get rights of the user from DB

            if (privilegeLevels.Contains(this.RoleID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> GetCredentialByLoggedInUser(int pk)
        {
            throw new NotImplementedException();
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/Error.cshtml"

            };
        }
        private List<string> GetCredentialByLoggedInUser(string userName)
        {
            var credentials = (List<string>)HttpContext.Current.Session[Common.CommonContants.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}