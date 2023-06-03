using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCRanks.Infrastructure.Persistence
{
    public class PCRanksDbContext : IdentityDbContext
    {
        public PCRanksDbContext(DbContextOptions<PCRanksDbContext> options) : base(options)
        {

        }
        public DbSet<Domain.Entities.PCRanks> PCRanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.PCRanks>()
                .OwnsOne(c => c.PCSpecs);
        }
    }
}
