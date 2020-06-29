using Jukebox.Core.Media.Contracts;
using System;
using System.Collections.Generic;

namespace Jukebox.Core.Media
{
    class VinylDisc : IMedia
    {
        Enums.EMediaType _mediaType = Enums.EMediaType.VinylDisc;

        public VinylDisc()
        {
        }
        public List<string> MaintenanceOptions { get; set; } = new List<string>() { "Clean up" };

        public Enums.EMediaType GetMediaType()
        {
            return _mediaType;
        }
    }
}
