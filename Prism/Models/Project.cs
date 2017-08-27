using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        /// <summary>
        /// 3 letter code
        /// </summary>
        [Required()]
        [StringLength(3, MinimumLength = 3)]
        public string Code { get; set; }

        [Required()]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public virtual List<Consultant> Consultants { get; set; }
    }
}