using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHSTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHSTest.Persistence.Models
{
    internal class RequirementsConfiguration : IEntityTypeConfiguration<Requirements>
    {
        public void Configure(EntityTypeBuilder<Requirements> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
