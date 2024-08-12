using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseRelated.Models
{
    public class Student
    {
        [Key]
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}