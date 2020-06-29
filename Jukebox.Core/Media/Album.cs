using Jukebox.Core.Media.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jukebox.Core.Media
{
    class Album : IAlbum
    {
        public string Name { get; set; }

        public string Autor { get; set; }

        public string Composer { get; set; }

        public List<string> Songs { get; set; }

        public int Duration { get; set; }

        public int Year { get; set; }
        public IMedia Media { get; set; }
    }
}
