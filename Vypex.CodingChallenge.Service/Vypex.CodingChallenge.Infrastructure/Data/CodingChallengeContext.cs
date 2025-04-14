using Microsoft.EntityFrameworkCore;
using Vypex.CodingChallenge.Domain;
using Vypex.CodingChallenge.Domain.Models;
using Vypex.CodingChallenge.Infrastructure.Config;

namespace Vypex.CodingChallenge.Infrastructure.Data
{
    public class CodingChallengeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<LeaveDay> LeaveDays { get; set; } = default!;

        public CodingChallengeContext()
        {
        }

        public CodingChallengeContext(DbContextOptions<CodingChallengeContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseSeeding((context, _) =>
            {
                context.Set<Employee>().AddRange(FakeEmployeesSeed.Generate(20));
                context.SaveChanges();
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveDayConfiguration).Assembly);
        }
    }
}
