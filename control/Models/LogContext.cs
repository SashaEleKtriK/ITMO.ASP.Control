using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace control.Models
{
    public class LogContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<ClassLog> ClassLogs { get; set; }
        public DbSet<LessonsTable> LessonsTable { get; set; }
        public DbSet<Week> Week { get; set; }
    }
}