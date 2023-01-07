using Composite_Design_Patterns.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composite_Design_Patterns.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;initial catalog=DbCompositeProject;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Clothes> Clothes { get; set; } 
    }
}
