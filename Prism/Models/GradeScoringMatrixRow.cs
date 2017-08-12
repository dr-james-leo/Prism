using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class GradeScoringMatrixRow
    {
        public Grade DesiredGrade { get; set; }
        public List<GradeScoringMatrixCell> SubstituteGrades { get; set; }
    }
}