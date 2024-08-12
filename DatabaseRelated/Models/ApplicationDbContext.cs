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
        {

        }

        //Add models for Create/Delete/Update of Table
        DbSet<Student> Student { get; set; }
    }
}