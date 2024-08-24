using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseRelated.Models
{
    public class Student
    {
        [Key]
        public int RollNumber { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public string FName { get; set; }

        //public int DegreeId { get; set; }
        public Degree  Degree { get; set; }

        
        ICollection<Semeter> Semeters { get; set; }
    }
}