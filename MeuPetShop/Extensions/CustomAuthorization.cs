using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Extensions
{
    public class CustomAuthorization
    {

        public static bool ValidarClaimsUsuario(HttpContext context,string claimnName,string claimValue)
        {
            return context.User.Identity.IsAuthenticated && context.User.Claims.Any(c => c.Type == claimnName && c.Value.Contains(claimValue));
        }
        public class ClaimsAuthorizeAttribute : TypeFilterAttribute
        {
            public ClaimsAuthorizeAttribute(string claimname,string claimvalue) : base(typeof(RequisitoClaimFilter))
            {
                Arguments = new object[] { new Claim(claimname, claimvalue) };
            }
        }
        public class RequisitoClaimFilter : IAuthorizationFilter
        {
            readonly Claim _claim;

            public RequisitoClaimFilter(Claim claim)
            {
                _claim = claim;
            }
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
