using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prism.Models
{
    /// <summary>
    /// A client of ours
    /// </summary>
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}