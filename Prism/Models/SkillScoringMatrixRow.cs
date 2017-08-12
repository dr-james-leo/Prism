using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class SkillScoringMatrixRow
    {
        public Skill DesiredSkill { get; set; }
        public List<SkillScoringMatrixCell> SubstituteSkills { get; set; }
    }
}