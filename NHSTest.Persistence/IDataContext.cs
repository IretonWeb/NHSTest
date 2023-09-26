using Microsoft.EntityFrameworkCore;
using NHSTest.Domain.Entities;
using NHSTest.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHSTest.Persistence
{
    public interface IDataContext
    {
        public DbSet<Staff> Staff { get; set; }

        public DbSet<Requirements> Requirements { get; set; }

        Task SaveChangesAsync(CancellationToken  cancellationToken = default);
    }
}
