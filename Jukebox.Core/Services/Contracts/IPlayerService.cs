using Jukebox.Core.Media.Contracts;

namespace Jukebox.Core.Services.Contracts
{
    public interface IPlayerService
    {
        Enums.EDeviceStatus InitializePlayer();
        void ChangeSelector(ISelectorService selector);
        void Play(IAlbum album, int songIndex);
        void Maintenance(IAlbum album, int optionIndex);
    }
}
