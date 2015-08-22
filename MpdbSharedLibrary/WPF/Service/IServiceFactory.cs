using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;
using MpdBaileyTechnology.Shared.WPF.Service.Implementation;

namespace MpdBaileyTechnology.Shared.WPF.Service
{
    public interface IServiceFactory
    {
        ServiceContainer CreateServices();
    }
}
