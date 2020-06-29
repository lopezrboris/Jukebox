using Jukebox.Core;
using Jukebox.Core.Configuration;
using Jukebox.Core.DI;
using Jukebox.Core.Media.Contracts;
using Jukebox.Core.Services;
using Jukebox.Core.Services.Contracts;
using System;

namespace Jukebox
{
    class Program
    {
        private static IPlayerService _JuckeBoxPlayer;
        private static IConfigurationService _Configuration;
        static void Main(string[] args)
        {
            InitializeJukebox();
            ShowMenu();
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("OPTIONS");
            Console.WriteLine("1. Maintenance.");
            Console.WriteLine("2. Play music.");
            Console.WriteLine("3. Exit.");
            string option = string.Empty;
            int converted;
            while (!int.TryParse(option, out converted) || int.Parse(option) < 1 || int.Parse(option) > 3)
            {
                Console.Write("Select an opbion: ");
                option = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
            };
            switch (converted)
            {
                case 1:
                    Maintenance();
                    break;
                case 2:
                    PlayMusic();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Maintenance(char keepPlaying = 'y')
        {
            if (!keepPlaying.Equals('y')) ShowMenu();

            Console.Clear();
            Console.WriteLine("MAINTENANCE");
            var option = ShowAlbums();
            var selectedAlbum = _Configuration.Albums[option - 1];
            Console.WriteLine("Selected album: {0} ({1}).", selectedAlbum.Name, selectedAlbum.Media.GetMediaType());
            Console.WriteLine("Changing media to: {0}...", selectedAlbum.Media.GetMediaType().ToString());
            InjectionFactory.Instance.ChangeMediaType(selectedAlbum.Media.GetMediaType());
            _JuckeBoxPlayer.ChangeSelector(InjectionFactory.Instance.Get<ISelectorService>());
            Console.Clear();
            Console.WriteLine("SELECT A MAINTENANCE OPTION");
            option = ShowMaintenanceOptions(_Configuration.Albums[option - 1]);
            var selectedOption = selectedAlbum.Media.MaintenanceOptions[option - 1];
            Console.WriteLine("Selected option: {0}.", selectedOption);
            _JuckeBoxPlayer.Maintenance(selectedAlbum, option - 1);
            Console.WriteLine();

            Console.Write("Would you like to keep doing maintenance ? (y/n) : ");
            keepPlaying = Console.ReadKey().KeyChar;
            Maintenance(keepPlaying);
        }

        private static void PlayMusic(char keepPlaying = 'y')
        {
            if (!keepPlaying.Equals('y')) ShowMenu();

            Console.Clear();
            Console.WriteLine("PLAY MUSIC");
            var option = ShowAlbums();
            var selectedAlbum = _Configuration.Albums[option - 1];
            Console.WriteLine("Selected album: {0} ({1}).", selectedAlbum.Name, selectedAlbum.Media.GetMediaType());
            Console.WriteLine("Changing media to: {0}...", selectedAlbum.Media.GetMediaType().ToString());
            InjectionFactory.Instance.ChangeMediaType(selectedAlbum.Media.GetMediaType());
            _JuckeBoxPlayer.ChangeSelector(InjectionFactory.Instance.Get<ISelectorService>());
            Console.Clear();
            Console.WriteLine("SELECT A SONG");
            option = ShowSongs(_Configuration.Albums[option - 1]);
            var selectedSong = selectedAlbum.Songs[option - 1];
            Console.WriteLine("Selected song: {0}.", selectedSong);
            _JuckeBoxPlayer.Play(selectedAlbum, option - 1);
            Console.WriteLine();

            Console.Write("Would you like to keep playing music ? (y/n) : ");
            keepPlaying = Console.ReadKey().KeyChar;
            PlayMusic(keepPlaying);
        }

        private static int ShowMaintenanceOptions(IAlbum album)
        {
            Console.WriteLine("Maintenance for {0} ({1}):", album.Name, album.Media.GetMediaType());
            int index = 1;
            foreach (var mOption in album.Media.MaintenanceOptions)
            {
                Console.WriteLine(@"{0}. {1}.", index, mOption);
                index++;
            }
            string option = string.Empty;
            int converted;
            while (!int.TryParse(option, out converted) || int.Parse(option) < 1 || int.Parse(option) > album.Media.MaintenanceOptions.Count)
            {
                Console.Write("Select an option: ");
                option = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
            }
            return converted;
        }

        private static int ShowSongs(IAlbum album)
        {
            Console.WriteLine("Songs for {0} ({1}):", album.Name, album.Media.GetMediaType());
            int index = 1;
            foreach (var song in album.Songs)
            {
                Console.WriteLine(@"{0}. {1}.", index, song);
                index++;
            }
            string option = string.Empty;
            int converted;
            while (!int.TryParse(option, out converted) || int.Parse(option) < 1 || int.Parse(option) > album.Songs.Count)
            {
                Console.Write("Select a song: ");
                option = Console.ReadLine();
                Console.WriteLine();
            }
            return converted;
        }

        private static int ShowAlbums()
        {
            int index = 1;
            foreach (var album in _Configuration.Albums)
            {
                Console.WriteLine(@"{0}. {1} - {2} - {3} minutes ({4}).", index, album.Name, album.Autor, album.Duration, album.Media.GetMediaType());
                index++;
            }
            string option = string.Empty;
            int converted;
            while (!int.TryParse(option, out converted) || int.Parse(option) < 1 || int.Parse(option) > _Configuration.Albums.Count)
            {
                Console.Write("Select an album: ");
                option = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
            }
            return converted;
        }

        private static void InitializeJukebox()
        {
            InjectionFactory.Instance.Load();
            _Configuration = InjectionFactory.Instance.Get<IConfigurationService>();
            _JuckeBoxPlayer = InjectionFactory.Instance.Get<PlayerService>();
            Enums.EDeviceStatus status = _JuckeBoxPlayer.InitializePlayer();

            if (status.Equals(Enums.EDeviceStatus.Ready))
            {
                Console.WriteLine("Device is ready to play!");
            }
            else
            {
                Console.WriteLine("There was a problem initializing...");
                Console.ReadKey();
            }
        }
    }
}
