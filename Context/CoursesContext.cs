using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace pr43savichev.Context
{
    public class CoursesContext : DbContext
    {
        public DbSet<Models.Courses> Courses { get; set; }

        public CoursesContext()
        {
            Database.EnsureCreated();
            Courses.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Config.Config.connection, Classes.Config.Config.version);
    }
}
