using TrainingPortal.Models;
using Xunit;

namespace TrainingPortal.UnitTests
{
    public class YoutubeUrlConverterTests
    {
        [Fact]
        public void ConvertWatchUrl()
        {
            string source = @"https://www.youtube.com/watch?v=1vgXud2uQf0&t=1s";
            string expected = @"https://www.youtube.com/embed/1vgXud2uQf0";

            string actual = YoutubeUrlConverter.Convert(source);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertShareUrl()
        {
            string source = @"https://youtu.be/1vgXud2uQf0";
            string expected = @"https://www.youtube.com/embed/1vgXud2uQf0";

            string actual = YoutubeUrlConverter.Convert(source);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConverEmdedUrl()
        {
            string source = @"https://www.youtube.com/embed/1vgXud2uQf0";
            string expected = @"https://www.youtube.com/embed/1vgXud2uQf0";

            string actual = YoutubeUrlConverter.Convert(source);
            Assert.Equal(expected, actual);
        }
    }
}
