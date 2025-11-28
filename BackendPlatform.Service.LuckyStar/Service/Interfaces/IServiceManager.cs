using ParentInterface = BackendPlatform.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parent = BackendPlatform.Service;

namespace BackendPlatform.Service.LuckyStar.Service.Interfaces
{
    public interface IServiceManager : ParentInterface.IServiceManagerBase
    {
        ICheckService CheckService { get; }
    }
}
