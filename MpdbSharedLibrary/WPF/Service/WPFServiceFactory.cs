using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;
using MpdBaileyTechnology.Shared.WPF.Service.Implementation;
using MpdBaileyTechnology.Shared.WPF.Service.Mock;

namespace MpdBaileyTechnology.Shared.WPF.Service
{
    public class WPFServiceFactory : IServiceFactory
    {
        public ServiceContainer CreateServices()
        {
            ServiceContainer container = new ServiceContainer();
            container.Register<IOpenFileDialog>(() => new Win32OpenFileDialog());
            container.Register<ISaveFileDialog>(() => new Win32SaveFileDialog());
            container.Register<IErrorDialog>(() => new Win32ErrorDialog());
            container.Register<IInformationDialog>(() => new Win32InformationDialog());
            container.Register<IPrintFlowDocument>(() => new PrintFlowDocument());
            container.Register<ITimerService>(() => new WpfTimerService());
            container.Register<IFolderBrowserDialog>(() => new Win32FolderBrowserDialog());
            return container;
        }
    }

}
