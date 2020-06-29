using System.Collections.Generic;

namespace Jukebox.Core.Media.Contracts
{
    public interface IAlbum
    {
        string Name { get; }
        string Autor { get; }
        string Composer { get; }
        List<string> Songs { get; }
        int Duration { get; }
        int Year { get; }
        string ToString();
        IMedia Media { get; set; }
    }
}
