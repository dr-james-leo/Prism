using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class SkillScoringMatrixCell
    {
        public int SkillScoringMatrixCellId { get; set; }

        //[Required]
        public virtual Skill DesiredSkill { get; set; }

        //[Required]
        public virtual Skill SubstituteSkill { get; set;}

        public int SubstituteScore { get; set; } // 0-10 where 0 is no substitute and 10 is perfect

    }
}