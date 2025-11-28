using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.Service.Interfaces
{
    // 基本上這邊會把 Base 裡面的所有介面都包含進來,
    // 並且該專案並不會進行實作, 會交由每個平台自己的 ServiceManager 去進行物件實際的產生
    public interface IServiceManagerBase
    {
        IAuthService AuthService { get; }
    }
}
