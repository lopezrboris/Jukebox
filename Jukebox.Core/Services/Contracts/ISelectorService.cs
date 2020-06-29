using Jukebox.Core.Media.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jukebox.Core.Services.Contracts
{
    public interface ISelectorService
    {
        Enums.EDeviceStatus PrepareSelector();
        Enums.EDeviceStatus Seek(IAlbum album, int songIndex);
        void Play();
        void Maintenance(IAlbum album, int optionIndex);
    }
}
