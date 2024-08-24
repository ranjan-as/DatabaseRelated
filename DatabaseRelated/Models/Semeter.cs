using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DatabaseRelated.Models
{
    public class Semeter
    {
        [Key]
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
    }
}