using BookStorePrueba.Models.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStorePrueba.Claims
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserTable, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<UserTable> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) 
            : base(userManager, roleManager, options) { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserTable user)
        {
            var identity= await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", user.FirstName));
            identity.AddClaim(new Claim("UserLastName", user.LastName));


            return identity;
        }

    }
}
