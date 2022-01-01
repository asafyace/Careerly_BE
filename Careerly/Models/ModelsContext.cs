using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Careerly.Models
{
    public class ModelsContext : DbContext
    {
        public ModelsContext(DbContextOptions<ModelsContext> options)
            : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<Experience> ?experience { get; set; }
        public DbSet<Course> ?course { get; set; }
        public DbSet<Award> ?award { get; set; }
        public DbSet<Education>? education { get; set; }
    }
}
