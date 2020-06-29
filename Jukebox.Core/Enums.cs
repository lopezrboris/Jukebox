using System;
using System.Collections.Generic;
using System.Text;

namespace Jukebox.Core
{
    public static class Enums
    {
        public enum EMediaType
        {
            VinylDisc,
            CompactDisc,
            AudioTape
        }

        public enum EDeviceStatus
        {
            Ready,
            Unprepared
        }
    }
}
