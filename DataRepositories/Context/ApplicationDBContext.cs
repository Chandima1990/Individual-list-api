using InSharpAssessment.DataRepositories.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InSharpAssessment.DataRepositories.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        { }

        #region DBSets
        public DbSet<Individual> Individuals { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;

        #endregion

        #region Common functions
        public async Task<bool> SaveChangesAsync()
        {
            return await SaveChangesAsync(true) >= 1;
        }

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            AuditEntities();
            return await base.SaveChangesAsync(
                acceptAllChangesOnSuccess,
                cancellationToken);
        }

        public override int SaveChanges()
        {
            AuditEntities();
            return base.SaveChanges();
        }

        private void AuditEntities()
        {
            var modifiedEntities = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added
                || e.State == EntityState.Modified);

            foreach (var entity in modifiedEntities)
            {
                entity.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
                if (entity.State == EntityState.Added)
                {
                    entity.Property("AddedDate").CurrentValue = DateTime.UtcNow;
                }
            }
        }

        #endregion

        #region Data Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Individual entity
            modelBuilder.Entity<Individual>().HasData(
                new Individual
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Addresses = new List<Address>
                    {
                        new Address { Id = 1, Street = "123 Main St", City = "New York", Country = "USA" },
                        new Address { Id = 2, Street = "456 Elm St", City = "Los Angeles", Country = "USA" }
                    },
                    PhoneNumber = "555-1234",
                    AgeInYears = 30
                },
                new Individual
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Addresses = new List<Address>
                    {
                        new Address { Id = 3, Street = "789 Oak St", City = "Chicago", Country = "USA" },
                        new Address { Id = 4, Street = "101 Maple St", City = "San Francisco", Country = "USA" }
                    },
                    PhoneNumber = "555-5678",
                    AgeInYears = 25
                }
            );
        }

        #endregion
    }
}
