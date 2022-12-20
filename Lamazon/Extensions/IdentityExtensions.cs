using Lamazon.ViewModels.Models;
using System.Security.Claims;

namespace Lamazon.Extensions
{
    public static class IdentityExtensions
    {
        public static string DisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? string.Empty;
        }
    }
}
