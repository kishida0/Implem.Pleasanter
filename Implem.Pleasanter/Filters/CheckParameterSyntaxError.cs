﻿using Implem.DefinitionAccessor;
using Implem.Pleasanter.Libraries.Requests;
using Implem.Pleasanter.Libraries.Responses;
using System.Linq;
using System.Web.Mvc;
namespace Implem.Pleasanter.Filters
{
    public class CheckParameterSyntaxError : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Routes.Controller() != "errors" &&  Parameters.SyntaxErrors?.Any() == true)
            {
                filterContext.Result = new RedirectResult(Locations.ParameterSyntaxError());
            }
        }
    }
}