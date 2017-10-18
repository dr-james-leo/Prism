using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class Consultant
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultantId { get; set; }

        [Required()]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required()]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; } // 1 is the highest level, then 2, 3, 4, etc

        [Required()]
        [StringLength(100)]
        public string Email { get; set; }

        public virtual List<Skill> Skills { get; set; }

        public int ProjectId { get; set; }
    }
}