using Jukebox.Core.Media.Contracts;
using System;
using System.Collections.Generic;

namespace Jukebox.Core.Media
{
    class CompactDisc : IMedia
    {
        Enums.EMediaType _mediaType = Enums.EMediaType.CompactDisc;

        public CompactDisc()
        {
        }
        public List<string> MaintenanceOptions { get; set; } = new List<string>() { "Clean up", "Fix scratches" };

        public Enums.EMediaType GetMediaType()
        {
            return _mediaType;
        }
    }
}
