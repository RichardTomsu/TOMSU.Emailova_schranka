﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Infrastructure.Database
{
    internal class DatabaseInit
    {
        public IList<Message> GetMessages() 
        { 
            IList<Message> messages = new List<Message>();
            messages.Add(new Message
            {
                Id = 1,
                Text = "Blakijdhalhfssjfah",
                Title = "Title",
                Odesilatel_Adress = "nkannkdk@sjajs",
                Created_at = "29.10.2023 17:27:58",
				Cil_adresa = "dads"
            });
            messages.Add(new Message
            {
                Id = 2,
                Text = "Blakijdhasadhdjkgadgajgdsgadgjadgjadjglhfssjfah",
                Title = "Titldadsae",
                Odesilatel_Adress = "nkannkdk@sjajs",
                Created_at = "20.10.2023 17:27:58",
				Cil_adresa = "dadsadsad"
            });
            return messages; 
        }
        public IList<Odeslani> GetOdeslani()
        {
            IList<Odeslani> list_odeslani = new List<Odeslani>();
            list_odeslani.Add(new Odeslani
            {
                Id = 1,
                Zprava_Id = 1,
                Prijemce_Adress = "nkannkdk@sjajs",
                Status = "Send",
            });
            return list_odeslani;
        }
        public IList<Spam> GetSpams()
        {
            IList<Spam> spams = new List<Spam>();
            spams.Add(new Spam
            {
				Id = 1,
				Uzivatel = "Blakijdhalhfssjfah",
                Blokovany_Uzivatel = "Title"
            });
            return spams;
        }

		public List<Role> CreateRoles()
		{
			List<Role> roles = new List<Role>();

			Role roleAdmin = new Role()
			{
				Id = 1,
				Name = "Admin",
				NormalizedName = "ADMIN",
				ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
			};

			Role roleManager = new Role()
			{
				Id = 2,
				Name = "Manager",
				NormalizedName = "MANAGER",
				ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
			};

			Role roleCustomer = new Role()
			{
				Id = 3,
				Name = "Customer",
				NormalizedName = "CUSTOMER",
				ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
			};


			roles.Add(roleAdmin);
			roles.Add(roleManager);
			roles.Add(roleCustomer);

			return roles;
		}


		public (User, List<IdentityUserRole<int>>) CreateAdminWithRoles()
		{
			User admin = new User()
			{
				Id = 1,
				FirstName = "Adminek",
				LastName = "Adminovy",
				UserName = "admin@emailik.cz",
				NormalizedUserName = "ADMIN",
				Email = "admin@admin.cz",
				NormalizedEmail = "ADMIN@ADMIN.CZ",
				EmailConfirmed = true,
				PasswordHash = "AQAAAAEAACcQAAAAEM9O98Suoh2o2JOK1ZOJScgOfQ21odn/k6EYUpGWnrbevCaBFFXrNL7JZxHNczhh/w==",
				SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
				ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
				PhoneNumber = null,
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnd = null,
				LockoutEnabled = true,
				AccessFailedCount = 0
			};

			List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
			{
				new IdentityUserRole<int>()
				{
					UserId = 1,
					RoleId = 1
				},
				new IdentityUserRole<int>()
				{
					UserId = 1,
					RoleId = 2
				},
				new IdentityUserRole<int>()
				{
					UserId = 1,
					RoleId = 3
				}
			};

			return (admin, adminUserRoles);
		}


		public (User, List<IdentityUserRole<int>>) CreateManagerWithRoles()
		{
			User manager = new User()
			{
				Id = 2,
				FirstName = "Managerek",
				LastName = "Managerovy",
				UserName = "manager",
				NormalizedUserName = "MANAGER",
				Email = "manager@manager.cz",
				NormalizedEmail = "MANAGER@MANAGER.CZ",
				EmailConfirmed = true,
				PasswordHash = "AQAAAAEAACcQAAAAEOzeajp5etRMZn7TWj9lhDMJ2GSNTtljLWVIWivadWXNMz8hj6mZ9iDR+alfEUHEMQ==",
				SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
				ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
				PhoneNumber = null,
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnd = null,
				LockoutEnabled = true,
				AccessFailedCount = 0
			};

			List<IdentityUserRole<int>> managerUserRoles = new List<IdentityUserRole<int>>()
			{
				new IdentityUserRole<int>()
				{
					UserId = 2,
					RoleId = 2
				},
				new IdentityUserRole<int>()
				{
					UserId = 2,
					RoleId = 3
				}
			};

			return (manager, managerUserRoles);
		}

	}
}
