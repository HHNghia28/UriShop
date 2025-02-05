using Microsoft.EntityFrameworkCore;
using Payment.Domain.Entities;
using Payment.Domain.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Domain.Entities.Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    (e.Entity is Domain.Entities.Payment) &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.Entity is Domain.Entities.Payment payment)
                {
                    if (entry.State == EntityState.Added)
                    {
                        payment.CreatedAt = DateUtility.GetCurrentDateTime();
                    }
                    payment.LastModifiedAt = DateUtility.GetCurrentDateTime();
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    (e.Entity is Domain.Entities.Payment) &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.Entity is Domain.Entities.Payment payment)
                {
                    if (entry.State == EntityState.Added)
                    {
                        payment.CreatedAt = DateUtility.GetCurrentDateTime();
                    }
                    payment.LastModifiedAt = DateUtility.GetCurrentDateTime();
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
