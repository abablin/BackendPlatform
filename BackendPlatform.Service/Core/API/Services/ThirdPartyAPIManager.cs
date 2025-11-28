using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendPlatform.Core.Helpers;
using BackendPlatform.Core.Models;
using BackendPlatform.Service.Core.API.Interfaces;

namespace BackendPlatform.Service.Core.API.Services
{
    public class ThirdPartyAPIManager : IThirdPartyAPIManager
    {
        private readonly Lazy<IW1Sevice> _w1;

        public ThirdPartyAPIManager(HttpHelper helper)
        {
            _w1 = new Lazy<IW1Sevice>(() => new W1Sevice(helper));
        }

        public IW1Sevice W1Sevice => _w1.Value;
    }
}
