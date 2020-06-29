using Ninject.Modules;
using Jukebox.Core.DI;
using Jukebox.Core.Services;
using Jukebox.Core.Configuration;
using Jukebox.Core.Services.Contracts;

namespace Jukebox.Core
{
    public class JukeboxModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigurationService>().To<ConfigurationService>().InSingletonScope();
            BindSelectorByConfiguration();
        }

        public void BindSelectorByConfiguration()
        {
            var configuration = InjectionFactory.Instance.Get<IConfigurationService>();
            BindSelector(configuration);
        }

        public void BindSelector(IConfigurationService configuration)
        {
            switch (configuration.MediaType)
            {
                case Enums.EMediaType.VinylDisc:
                    Rebind<ISelectorService>().To<VinylDiscSelectorService>();
                    break;
                case Enums.EMediaType.CompactDisc:
                    Rebind<ISelectorService>().To<CompactDiscSelectorService>();
                    break;
                case Enums.EMediaType.AudioTape:
                    Rebind<ISelectorService>().To<AudioTapeSelectorService>();
                    break;
                default:
                    Rebind<ISelectorService>().To<AudioTapeSelectorService>();
                    break;
            }
        }
    }
}
