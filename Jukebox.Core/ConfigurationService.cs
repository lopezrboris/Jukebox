using Jukebox.Core.Configuration;
using Jukebox.Core.Media;
using Jukebox.Core.Media.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Jukebox.Core
{
    public class ConfigurationService : IConfigurationService
    {
        public ConfigurationService()
        {
            LoadAlbums();
        }

        private void LoadAlbums()
        {
            Albums = new List<IAlbum>() {
                new Album() {
                    Name = "Album 1",
                    Autor = "Autor 1",
                    Composer = "Composer 1",
                    Duration = 30,
                    Songs = new List<string>(){ "Song 1.1", "Song 1.2", "Song 1.3" },
                    Year = 1,
                    Media = new AudioTape()
                },
                new Album() {
                    Name = "Album 2",
                    Autor = "Autor 2",
                    Composer = "Composer 2",
                    Duration = 30,
                    Songs = new List<string>(){ "Song 2.1", "Song 2.2", "Song 2.3" },
                    Year = 2,
                    Media = new CompactDisc()
                },
                new Album() {
                    Name = "Album 3",
                    Autor = "Autor 3",
                    Composer = "Composer 3",
                    Duration = 30,
                    Songs = new List<string>(){ "Song 3.1", "Song 3.2", "Song 3.3" },
                    Year = 3,
                    Media = new VinylDisc()
                },
                new Album() {
                    Name = "Get a Grip",
                    Autor = "Geffen Records",
                    Composer = "Aerosmith",
                    Duration = 62,
                    Songs = new List<string>(){ "Intro", "Eat the Rich", "Get a Grip", "Fever", "Livin' on the Edge", "Flesh", "Walk on Down",
                        "Shut Up and Dance", "Cryin'", "Gotta Love It", "Crazy", "Line Up (featuring Lenny Kravitz)", "Amazing", "Boogie Man (Instrumental)" },
                    Year = 1993,
                    Media = new CompactDisc()
                }};
            CurrentAlbum = (IAlbum)Albums.FirstOrDefault();
        }
        public Enums.EMediaType MediaType { get; set; } = Enums.EMediaType.AudioTape;
        public IAlbum CurrentAlbum { get; set; }
        public List<IAlbum> Albums { get; set; }
    }
}
