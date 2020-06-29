using Jukebox.Core.Media.Contracts;
using System.Collections.Generic;

namespace Jukebox.Core.Configuration
{
    public interface IConfigurationService
    {
        IAlbum CurrentAlbum { get; }
        Enums.EMediaType MediaType { get; set; }
        List<IAlbum> Albums { get; }
    }
}
