using System;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAdvanced.Entities.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options):base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=graphqlTest;Username=postgres;Password=ujhzyby12345");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid() };

            modelBuilder.ApplyConfiguration(new OwnerContextConfiguration(ids));
            modelBuilder.ApplyConfiguration(new AccountContextConfiguration(ids));
        }
        
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}