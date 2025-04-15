using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Vypex.CodingChallenge.Domain.Models;

namespace Vypex.CodingChallenge.Infrastructure.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {            
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasMany(e => e.Leaves)
               .WithOne(l => l.Employee)
               .HasForeignKey(l => l.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
