
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_management_system.Models;

namespace task_management_system.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public required DbSet<ProjectTask> ProjectTask { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is TimestampEntity && e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                ((TimestampEntity)entry.Entity).UpdatedAt = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is TimestampEntity && e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                ((TimestampEntity)entry.Entity).UpdatedAt = DateTime.Now;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}