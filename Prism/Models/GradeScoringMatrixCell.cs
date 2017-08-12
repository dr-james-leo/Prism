using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class GradeScoringMatrixCell
    {
        public int GradeScoringMatrixCellId { get; set; }

        //[Required]
        public virtual Grade DesiredGrade { get; set; }

        //[Required]
        public virtual Grade SubstituteGrade { get; set; }

        public int SubstituteScore { get; set; } // 0-10 where 0 is no substitute and 10 is perfect
    }
}