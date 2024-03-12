using Microsoft.AspNetCore.Authorization;
using Shared.Enums;
using System.Data;

namespace FirstGenericRepository.Api.Helpers
{
    public class AuthorizeRoles : AuthorizeAttribute
    {
        public AuthorizeRoles(params RoleEnum[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(RoleEnum), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
