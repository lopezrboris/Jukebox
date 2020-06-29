using Jukebox.Core.Media.Contracts;
using Jukebox.Core.Services.Contracts;

namespace Jukebox.Core.Services
{
    public class PlayerService : IPlayerService
    {
        ISelectorService _selector;

        public PlayerService(ISelectorService selector)
        {
            _selector = selector;
        }

        public Enums.EDeviceStatus InitializePlayer()
        {
            try
            {
                return _selector.PrepareSelector();
            }
            catch (System.Exception)
            {
                return Enums.EDeviceStatus.Unprepared;
            }
        }

        public void ChangeSelector(ISelectorService selector)
        {
            _selector = selector;
        }

        public void Play(IAlbum album, int songIndex)
        {
            _selector.Seek(album, songIndex);
            _selector.Play();
        }

        public void Maintenance(IAlbum album, int optionIndex)
        {
            _selector.Maintenance(album, optionIndex);
        }
    }
}
