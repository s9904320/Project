using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class StudentInfoT
    {
        [Key]
        public int recno { get; set; }
        public string? name { get; set; }
        public bool sex { get; set; }
        public int number { get; set; }
    }
}
