using Jukebox.Core.Media.Contracts;
using System;
using System.Collections.Generic;

namespace Jukebox.Core.Media
{
    class AudioTape : IMedia
    {
        Enums.EMediaType _mediaType = Enums.EMediaType.AudioTape;

        public AudioTape()
        {
        }

        public List<string> MaintenanceOptions { get; set; } = new List<string>() { "Rewinding", "Clean up", "Replace tape" };

        public Enums.EMediaType GetMediaType()
        {
            return _mediaType;
        }
    }
}
