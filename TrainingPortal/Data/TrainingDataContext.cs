using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrainingPortal.Models
{
    public class TrainingDataContext : IdentityDbContext<IdentityUser>
    {
        public TrainingDataContext (DbContextOptions<TrainingDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Course> Course { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
