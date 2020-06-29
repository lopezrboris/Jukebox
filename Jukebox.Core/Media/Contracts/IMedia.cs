using System.Collections.Generic;

namespace Jukebox.Core.Media.Contracts
{
    public interface IMedia
    {
        Enums.EMediaType GetMediaType();
        List<string> MaintenanceOptions { get; set; }
    }
}
