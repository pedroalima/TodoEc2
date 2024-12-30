using Microsoft.AspNetCore.Mvc;
using TodoEc2.API.Filters;

namespace TodoEc2.API.Attributes
{
    public class AuthenticatedUserAttribute : TypeFilterAttribute
    {
        public AuthenticatedUserAttribute() : base(typeof(AuthenticatedUserFilter))
        {
        }
    }
}
