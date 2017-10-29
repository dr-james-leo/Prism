using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        [Required]
        public int Level { get; set; } // 1 is highest and then 2, 3, 4, etc

        [Required()]
        [StringLength(100)]
        public string Name { get; set; }

        //public virtual List<Consultant> Consultants { get; set; }
    }
}