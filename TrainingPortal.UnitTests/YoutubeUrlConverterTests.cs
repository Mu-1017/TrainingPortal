using Moq;
using System;
using TrainingPortal.Models;
using Xunit;

namespace TrainingPortal.UnitTests
{
    public class YoutubeUrlConverterTests
    {
        private Mock<ITeamManager> _fakeManage;

        public YoutubeUrlConverterTests()
        {
            //Test moq
            _fakeManage = new Mock<ITeamManager>();
        }

        [Fact]
        public void ConvertWatchUrl()
        {
            string source = @"https://www.youtube.com/watch?v=1vgXud2uQf0&t=1s";
            string expected = @"https://www.youtube.com/embed/1vgXud2uQf0";

            string actual = YoutubeUrlConverter.Convert(source);
            Assert.Equal(expected, actual);
        }
    }
}
