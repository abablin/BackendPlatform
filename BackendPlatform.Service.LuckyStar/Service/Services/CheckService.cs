using BackendPlatform.Service.LuckyStar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.LuckyStar.Service.Services
{
    public class CheckService : ICheckService
    {
        public async Task<int> Check()
        {
            return await Task.FromResult(10);
        }
    }
}
