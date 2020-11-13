using Microsoft.EntityFrameworkCore;
using TestTaskDelaSchool.Models;

namespace TestTaskDelaSchool.Data
{
    public class ContextDB:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Founder> Founders { get; set; }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
