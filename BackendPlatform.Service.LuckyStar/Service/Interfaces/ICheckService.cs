using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.LuckyStar.Service.Interfaces
{
    public interface ICheckService
    {
        Task<int> Check();
    }
}
