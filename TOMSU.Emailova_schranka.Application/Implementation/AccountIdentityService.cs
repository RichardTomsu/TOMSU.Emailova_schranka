using Microsoft.AspNetCore.Identity;
using System;
using TOMSU.Emailova_schranka.Application.Abstraction;
using TOMSU.Emailova_schranka.Application.ViewModels;
using TOMSU.Emailova_schranka.Infrastructure.Identity;
using TOMSU.Emailova_schranka.Infrastructure.Identity.Enums;

namespace TOMSU.Emailova_schranka.Application.Implementation
{
    public class AccountIdentityService : IAccountService
    {
        UserManager<User> userManager;
        SignInManager<User> sigInManager;

        public AccountIdentityService(UserManager<User> userManager, SignInManager<User> sigInManager)
        {
            this.userManager = userManager;
            this.sigInManager = sigInManager;
        }

        public async Task<bool> Login(LoginViewModel vm)
        {
            var result = await sigInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
            return result.Succeeded;
        }

        public Task Logout()
        {
            return sigInManager.SignOutAsync();
        }
        public async Task<string[]> Register(RegisterViewModel vm, Roles role)
        {
            User user = new User()
            {
                UserName = vm.Username + "@emailik.cz",
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Username + "@emailik.cz",
                PhoneNumber = "194"
            };

            string[] errors = null;

            var result = await userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                var resultRole = await userManager.AddToRoleAsync(user, role.ToString());

                if (resultRole.Succeeded == false)
                {
                    for (int i = 0; i < result.Errors.Count(); ++i)
                        result.Errors.Append(result.Errors.ElementAt(i));
                }
            }
            else
            {
                Console.WriteLine("dsds");
            }

            if (result.Errors != null && result.Errors.Count() > 0)
            {
                errors = new string[result.Errors.Count()];
                for (int i = 0; i < result.Errors.Count(); ++i)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }
            }
            else
            {
                Console.WriteLine("aaaa");
            }

            return errors;
        }
    }
}
