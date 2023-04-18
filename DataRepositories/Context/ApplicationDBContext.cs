using InSharpAssessment.DataRepositories.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InSharpAssessment.DataRepositories.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            Database.EnsureCreatedAsync();
        }

        #region DBSets
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Address> Addresses { get; set; }

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
            // Configure seed data for 'Individual' entity
            modelBuilder.Entity<Individual>().HasData(
                new Individual { Id = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "5551234458", AgeInYears = 30 },
                new Individual { Id = 2, FirstName = "Jane", LastName = "Pifer", PhoneNumber = "5555678365", AgeInYears = 28 }
            );

            // Configure seed data for 'Address' entity
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "123 Main St", City = "New York", Country = "USA", IndividualId = 1 },
                new Address { Id = 2, Street = "456 Elm St", City = "Los Angeles", Country = "USA", IndividualId = 1 },
                new Address { Id = 3, Street = "789 Oak St", City = "Chicago", Country = "USA", IndividualId = 2 }
            );

            // Define relationships between entities
            modelBuilder.Entity<Individual>()
                .HasMany(i => i.Addresses)
                .WithOne(a => a.Individual)
                .HasForeignKey(a => a.IndividualId);

            // Other modelBuilder configurations
        }
        #endregion
    }
}
