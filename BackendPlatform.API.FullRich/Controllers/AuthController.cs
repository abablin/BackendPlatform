using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentAPI = BackendPlatform.API;
using Parent = BackendPlatform.Service;
using SelfService = BackendPlatform.Service.FullRich;
using BackendPlatform.Service.FullRich.Service.Interfaces;
//using BackendPlatform.Service.Interfaces;

namespace BackendPlatform.API.FullRich.Controllers
{
    [ApiController]
    [Area("FullRich")]
    public class AuthController: ParentAPI.Controllers.AuthController
    {
        private readonly IServiceManager _serviceManager;

        public AuthController(IServiceManager serviceManager) : base(serviceManager)
        {
            _serviceManager = serviceManager;
        }
    }
}
