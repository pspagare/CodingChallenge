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
    public class LeaveDayConfiguration : IEntityTypeConfiguration<LeaveDay>
    {
        public void Configure(EntityTypeBuilder<LeaveDay> builder)
        {
            builder.Property(l => l.StartDate).IsRequired();
            builder.Property(l => l.EndDate).IsRequired();
        }
    }
}
