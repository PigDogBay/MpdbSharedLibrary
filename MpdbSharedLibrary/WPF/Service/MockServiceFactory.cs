using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;
using MpdBaileyTechnology.Shared.WPF.Service.Implementation;
using MpdBaileyTechnology.Shared.WPF.Service.Mock;

namespace MpdBaileyTechnology.Shared.WPF.Service
{
    public class MockServiceFactory : IServiceFactory
    {
        public ServiceContainer CreateServices()
        {
            ServiceContainer container = new ServiceContainer();
            container.Register<IOpenFileDialog>(() => new MockOpenFileDialog());
            container.Register<ISaveFileDialog>(() => new MockSaveFileDialog());
            container.Register<IErrorDialog>(() => new MockErrorDialog());
            container.Register<IInformationDialog>(() => new MockInformationDialog());
            container.Register<IPrintFlowDocument>(() => new MockPrintFlowDocument());
            container.Register<ITimerService>(() => new MockTimerService());
            container.Register<IFolderBrowserDialog>(() => new MockFolderBrowserDiualog());
            return container;
        }
    }
}
