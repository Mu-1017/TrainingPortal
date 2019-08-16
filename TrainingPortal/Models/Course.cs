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
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Posted { get; set; }

        static readonly Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
        static readonly Regex VimeoVideoRegex = new Regex(@"vimeo\.com/(?:.*#|.*/videos/)?([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public string GetEmbedSource()
        {
            if (string.IsNullOrEmpty(Source))
            {
                return Source;
            }
            else
            {
                var youtubeMatch = YoutubeVideoRegex.Match(Source);

                if (youtubeMatch.Success)
                {
                    string result = getYoutubeEmbedCode(youtubeMatch.Groups[youtubeMatch.Groups.Count - 1].Value);
                    return result;
                }
                else
                    return Source;
            }
        }

        const string youtubeEmbedFormat = @"https://www.youtube.com/embed/{0}";

        private static string getYoutubeEmbedCode(string youtubeId)
        {
            return string.Format(youtubeEmbedFormat, youtubeId);
        }
    }
}
