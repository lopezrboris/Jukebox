using Jukebox.Core.Configuration;
using Jukebox.Core.Media.Contracts;
using Jukebox.Core.Services.Contracts;
using System;

namespace Jukebox.Core.Services
{
    class CompactDiscSelectorService : ISelectorService
    {
        Enums.EMediaType _MediaType = Enums.EMediaType.CompactDisc;
        IAlbum _currentAlbum;
        string _currentSong;
        IConfigurationService _configurationService;

        public CompactDiscSelectorService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public void Maintenance(IAlbum album, int optionIndex)
        {
            Console.WriteLine(@"{0} process for {1} ({2})....", album.Media.MaintenanceOptions[optionIndex], album.Name, album.Media.GetMediaType());
        }

        public void Play()
        {
            Console.WriteLine(@"Playing {0}, in {1} media....", _currentSong, _MediaType.ToString());
        }

        public Enums.EDeviceStatus PrepareSelector()
        {
            try
            {
                _currentAlbum = _configurationService.CurrentAlbum;
                return Enums.EDeviceStatus.Ready;
            }
            catch (Exception)
            {
                return Enums.EDeviceStatus.Unprepared;
            }
        }

        public Enums.EDeviceStatus Seek(IAlbum album, int songIndex)
        {
            _currentAlbum = album;
            if (album.Songs.Count >= songIndex)
            {
                _currentSong = album.Songs[songIndex];
                Console.WriteLine(@"Ready to play {0}, song index {1}", _currentAlbum.Name, songIndex + 1);
                return Enums.EDeviceStatus.Ready;
            }
            else
            {
                return Enums.EDeviceStatus.Unprepared;
            }
        }
    }
}
