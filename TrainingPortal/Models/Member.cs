using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingPortal.Models
{
    public class Member
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(maximumLength:100, MinimumLength =5)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Title { get; set; }

        [StringLength(maximumLength: 200)]
        public string Description { get; set; }
    }
}
