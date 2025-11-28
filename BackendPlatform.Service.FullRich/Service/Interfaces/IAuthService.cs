using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentInterface = BackendPlatform.Service.Service.Interfaces;

namespace BackendPlatform.Service.FullRich.Service.Interfaces
{
    // 這邊的 Service 只會定義特定平台自己用的服務
    public interface IAuthService : ParentInterface.IAuthService
    {
        Task AAA();
    }
}
