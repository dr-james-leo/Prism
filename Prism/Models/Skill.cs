using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class Skill
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [Required()]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual List<Consultant> Consultants { get; set; }
    }
}