using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Application.Abstraction
{
	public interface ISecurityService
	{
		Task<User> FindUserByUsername(string username);
		Task<User> FindUserByEmail(string email);
		Task<IList<string>> GetUserRoles(User user);
		Task<User> GetCurrentUser(ClaimsPrincipal principal);
	}
}
