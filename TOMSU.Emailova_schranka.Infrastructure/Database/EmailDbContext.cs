using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOMSU.Emailova_schranka.Domain.Entities;

namespace TOMSU.Emailova_schranka.Infrastructure.Database
{
    public class EmailDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Odeslani> Odeslani { get; set;}

        public EmailDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DatabaseInit dbInit = new DatabaseInit();
            modelBuilder.Entity<Message>().HasData(dbInit.GetMessages());
            
            modelBuilder.Entity<Odeslani>().HasData(dbInit.GetOdeslani());
        }
    }
}
