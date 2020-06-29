using Jukebox.Core.Configuration;
using Jukebox.Core.Services;
using Jukebox.Core.Services.Contracts;
using Ninject;
using System;

namespace Jukebox.Core.DI
{
    public class InjectionFactory
    {
        private static InjectionFactory _InjectionFactoryInstance;
        private IKernel _Kernel;

        public InjectionFactory()
        {
            _Kernel = new StandardKernel();
        }

        public static InjectionFactory Instance
        {
            get
            {
                if (_InjectionFactoryInstance == null)
                {
                    _InjectionFactoryInstance = new InjectionFactory();
                }
                return _InjectionFactoryInstance;
            }
        }
        public T Get<T>()
        {
            return _Kernel.Get<T>();
        }
        public void Load()
        {
            _Kernel.Load("Jukebox.*.dll");
        }
        public void ChangeMediaType(Enums.EMediaType mediaType)
        {
            var configurationService = _Kernel.Get<IConfigurationService>();
            configurationService.MediaType = mediaType;
            _Kernel.Rebind<IConfigurationService>().ToConstant(configurationService);
            BindSelector(configurationService);
            Console.WriteLine("Media type has been changed to: {0}.", configurationService.MediaType);
        }

        public void BindSelector(IConfigurationService configuration)
        {
            switch (configuration.MediaType)
            {
                case Enums.EMediaType.VinylDisc:
                    _Kernel.Rebind<ISelectorService>().To<VinylDiscSelectorService>();
                    break;
                case Enums.EMediaType.CompactDisc:
                    _Kernel.Rebind<ISelectorService>().To<CompactDiscSelectorService>();
                    break;
                case Enums.EMediaType.AudioTape:
                    _Kernel.Rebind<ISelectorService>().To<AudioTapeSelectorService>();
                    break;
                default:
                    _Kernel.Rebind<ISelectorService>().To<AudioTapeSelectorService>();
                    break;
            }
        }
    }
}
