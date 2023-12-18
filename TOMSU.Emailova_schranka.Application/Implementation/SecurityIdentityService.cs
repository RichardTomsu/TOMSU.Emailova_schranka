using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Application.Implementation
{
    public class SecurityIdentityService : ISecurityService
    {
        UserManager<User> userManager;
        public SecurityIdentityService(UserManager<User> userManager) 
        { 
            this.userManager = userManager;
        }

        Task<User> ISecurityService.FindUserByUsername(string username)
        {
            return userManager.FindByNameAsync(username);
        }

        Task<User> ISecurityService.GetCurrentUser(ClaimsPrincipal principal)
        {
            return userManager.GetUserAsync(principal);
        }

        Task<IList<string>> ISecurityService.GetUserRoles(User user)
        {
            return userManager.GetRolesAsync(user);
        }
    }
}
