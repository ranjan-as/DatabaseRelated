using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DatabaseRelated.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        : base("Default")
        {
        }

        public System.Data.Entity.DbSet<DatabaseRelated.Models.Student> Students { get; set; }
        public System.Data.Entity.DbSet<DatabaseRelated.Models.Degree> Degrees { get; set; }

        public System.Data.Entity.DbSet<DatabaseRelated.Models.Semeter> Semeter { get; set; }
    }
}