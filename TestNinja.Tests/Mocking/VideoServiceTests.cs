using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void GetUnprocessedVideosAsCsv_When3UnprocessedVideosExist_ReturnAll3InCSV()
        {
            var videoRepository = new Mock<IVideoRepository>();
            videoRepository.Setup(t => t.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3}
            });

            var videoSvc = new VideoService(videoRepository.Object);

            var result = videoSvc.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenNoUnprocessedVideosExist_ReturnEmptyString()
        {
            var videoRepository = new Mock<IVideoRepository>();
            videoRepository.Setup(t => t.GetUnprocessedVideos()).Returns(new List<Video>());

            var videoSvc = new VideoService(videoRepository.Object);

            var videos = videoSvc.GetUnprocessedVideosAsCsv();

            Assert.That(videos, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_When1UnprocessedVideosExist_ReturnOneVideo()
        {
            var videoRepository = new Mock<IVideoRepository>();
            videoRepository.Setup(t => t.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video {Id = 3}
            });

            var videoSvc = new VideoService(videoRepository.Object);

            var result = videoSvc.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("3"));
        }
    }
}
