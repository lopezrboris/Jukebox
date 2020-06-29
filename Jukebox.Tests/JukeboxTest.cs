using FluentAssertions;
using Jukebox.Core;
using Jukebox.Core.Media.Contracts;
using Jukebox.Core.Services;
using Jukebox.Core.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Jukebox.Tests
{
    [TestClass]
    public class JukeboxTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void InitializeJukeboxTest()
        {
            Mock<ISelectorService> selectorService = new Mock<ISelectorService>();
            selectorService.Setup(service => service.PrepareSelector()).Returns(Enums.EDeviceStatus.Ready);

            var jukeboxPlayer = new PlayerService(selectorService.Object);

            Enums.EDeviceStatus status = jukeboxPlayer.InitializePlayer();

            status.Should().Be(Enums.EDeviceStatus.Ready);
            selectorService.Verify(service => service.PrepareSelector(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void SeekAndPlayASongTest()
        {
            Mock<ISelectorService> selectorService = new Mock<ISelectorService>();
            selectorService.Setup(service => service.PrepareSelector()).Returns(Enums.EDeviceStatus.Ready);

            var jukeboxPlayer = new PlayerService(selectorService.Object);

            jukeboxPlayer.ChangeSelector(selectorService.Object);

            Enums.EDeviceStatus status = jukeboxPlayer.InitializePlayer();
            status.Should().Be(Enums.EDeviceStatus.Ready);
            selectorService.Verify(service => service.PrepareSelector(), Times.AtLeastOnce);

            jukeboxPlayer.Play(new Mock<IAlbum>().Object, 1);

            selectorService.Verify(selector => selector.Seek(It.IsAny<IAlbum>(), It.IsAny<int>()), Times.AtLeastOnce);
            selectorService.Verify(selector => selector.Play(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void MediaMaintenanceTest()
        {
            Mock<ISelectorService> selectorService = new Mock<ISelectorService>();
            selectorService.Setup(service => service.PrepareSelector()).Returns(Enums.EDeviceStatus.Ready);

            var jukeboxPlayer = new PlayerService(selectorService.Object);

            jukeboxPlayer.ChangeSelector(selectorService.Object);

            Enums.EDeviceStatus status = jukeboxPlayer.InitializePlayer();
            status.Should().Be(Enums.EDeviceStatus.Ready);
            selectorService.Verify(service => service.PrepareSelector(), Times.AtLeastOnce);

            jukeboxPlayer.Maintenance(new Mock<IAlbum>().Object, 1);

            selectorService.Verify(selector => selector.Maintenance(It.IsAny<IAlbum>(), It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}
