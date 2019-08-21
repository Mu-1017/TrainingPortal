using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrainingPortal.Models
{
    public static class YoutubeUrlConverter
    {
        const string youtubeEmbedFormat = @"https://www.youtube.com/embed/{0}";

        static readonly Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
        static readonly Regex VimeoVideoRegex = new Regex(@"vimeo\.com/(?:.*#|.*/videos/)?([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        public static string Convert(string orinalSource)
        {
            if (string.IsNullOrEmpty(orinalSource))
            {
                return orinalSource;
            }
            else
            {
                var youtubeMatch = YoutubeVideoRegex.Match(orinalSource);

                if (youtubeMatch.Success)
                {
                    string result = getYoutubeEmbedCode(youtubeMatch.Groups[youtubeMatch.Groups.Count - 1].Value);
                    return result;
                }
                else
                    return orinalSource;
            }
        }

        private static string getYoutubeEmbedCode(string youtubeId)
        {
            return string.Format(youtubeEmbedFormat, youtubeId);
        }
    }
}
