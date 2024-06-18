using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace pr43savichev.Context
{
    public class StudentsContext : DbContext
    {
        public DbSet<Models.Students> Students { get; set; }

        public StudentsContext()
        {
            Database.EnsureCreated();
            Students.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Config.Config.connection, Classes.Config.Config.version);
    }
}
