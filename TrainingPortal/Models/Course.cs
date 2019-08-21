using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrainingPortal.Models
{
    public class Course
    {
        [Key]
        public long CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public string Author { get; set; }

        [Required]
        public string Source { get; set; }
        public long CategoryId { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Posted { get; set; }

        public string GetEmbedSource()
        {
            return YoutubeUrlConverter.Convert(Source);
        }
    }
}
