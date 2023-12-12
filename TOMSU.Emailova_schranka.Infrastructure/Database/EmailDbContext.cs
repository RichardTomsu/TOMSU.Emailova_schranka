using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TOMSU.Emailova_schranka.Domain.Entities;
using TOMSU.Emailova_schranka.Infrastructure.Identity;

namespace TOMSU.Emailova_schranka.Infrastructure.Database
{
    public class EmailDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Odeslani> Odeslani { get; set;}

        public EmailDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
			DatabaseInit dbInit = new DatabaseInit();
			modelBuilder.Entity<Message>().HasData(dbInit.GetMessages());
            
            modelBuilder.Entity<Odeslani>().HasData(dbInit.GetOdeslani());

			modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

			//then, create users ..
			(User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
			(User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

			//.. and add them to the table
			modelBuilder.Entity<User>().HasData(admin, manager);

			//and finally, connect the users with the roles
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);

		}
    }
}
