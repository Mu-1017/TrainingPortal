using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingPortal.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
