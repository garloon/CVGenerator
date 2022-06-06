using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CVGenerator.Web.Models
{
    public class CurrentUser
    {
        public ClaimsPrincipal Principal;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            SetPrincipal(accessor.HttpContext.User);
        }

        public void SetPrincipal(ClaimsPrincipal principal)
        {
            Principal = principal;
        }

        public string UserName
        {
            get => Get(ClaimTypes.Name);
            set => AddOrUpdate(ClaimTypes.Name, value);
        }

        public string UserId
        {
            get => Get(ClaimTypes.NameIdentifier);
            set => AddOrUpdate(ClaimTypes.NameIdentifier, value);
        }

        public string UserRole
        {
            get => Get(ClaimTypes.Role);
            set => AddOrUpdate(ClaimTypes.Role, value);
        }

        private string Get(string type) => Principal.FindFirstValue(type);

        private void AddOrUpdate(string type, string value)
        {
            if (!(Principal.Identity is ClaimsIdentity identity))
            {
                return;
            }

            var existingClaim = identity.FindFirst(type);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            identity.AddClaim(new Claim(type, value));
        }
    }
}
