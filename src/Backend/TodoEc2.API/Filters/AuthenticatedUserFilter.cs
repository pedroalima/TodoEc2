using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using TodoEc2.Communication.Responses;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Domain.Security.Tokens;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.API.Filters
{
    public class AuthenticatedUserFilter : IAsyncAuthorizationFilter
    {
        private readonly IAccessTokenValidator _accessTokenValidator;
        private readonly IUserReadOnlyRepository _repository;

        public AuthenticatedUserFilter(IAccessTokenValidator accessTokenValidator, IUserReadOnlyRepository repository)
        {
            _accessTokenValidator = accessTokenValidator;
            _repository = repository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context);

                var userIdentifier = _accessTokenValidator.ValidateAndGetUserIdentifier(token);

                var existingUser = await _repository.ExistActiveUserWithIdentifier(userIdentifier);

                if (!existingUser)
                {
                    throw new TodoEc2Exceptions("Usuário inexistente");
                }
            }
            catch (SecurityTokenExpiredException)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("Token is expired")
                {
                    TokenIsExpired = true,
                });
            }
            catch (TodoEc2Exceptions ex)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ex.Message));
            }
            catch
            {
                context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("Usuário sem permissão"));
            }
        }

        private static string TokenOnRequest(AuthorizationFilterContext context)
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
