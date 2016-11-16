using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DemoWebApi
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent("<p> Use HTTPS instead of HTTP </p>");

                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
                uriBuilder.Scheme = Uri.UriSchemeHttps;
                uriBuilder.Port = 44399;

                actionContext.Response.Headers.Location = uriBuilder.Uri;
            }

            else
            {
                base.OnAuthorization(actionContext);
            }

        }
    }
}