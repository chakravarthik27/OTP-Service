using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> GetUser { get; set; }

        public DbSet<OTPMessage> GetOTPMessages { get; set; }

        public DbSet<apikeycontrol> getAPI { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<OTPMessage>().ToTable("OTPMessages");
            builder.Entity<apikeycontrol>().ToTable("API_Key_Management");
        }
    }
}
