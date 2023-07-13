using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebmvc.Models;

namespace SalesWebmvc.Model
{
    public class SalesWebmvcContext : DbContext
    {
        public SalesWebmvcContext (DbContextOptions<SalesWebmvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;

        public DbSet<Saller> Saller { get; set; }

        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
