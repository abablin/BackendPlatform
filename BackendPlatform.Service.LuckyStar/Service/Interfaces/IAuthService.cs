using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentInterface = BackendPlatform.Service.Service.Interfaces;

namespace BackendPlatform.Service.LuckyStar.Service.Interfaces
{
    public interface IAuthService : ParentInterface.IAuthService
    {
        Task RunMyMethod();
    }
}
