using Microsoft.AspNetCore.Mvc.Filters;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.API.Attributes
{
    public class AuthenticatedUserAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var token = TokenOnRequest(context);
        }

        private string TokenOnRequest(AuthorizationFilterContext context)
        {
            var authentication = context.HttpContext.Request.Headers.Authorization.ToString();

            if (string.IsNullOrWhiteSpace(authentication)) 
            {
                throw new TodoEc2Exceptions("Não há token de autenticação");
            }

            return authentication["Bearer ".Length..].Trim();
        }
    }
}
