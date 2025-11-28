using BackendPlatform.Service.LuckyStar.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentAPI = BackendPlatform.API;
using ParentService = BackendPlatform.Service;
using SelfService = BackendPlatform.Service.LuckyStar;

namespace BackendPlatform.API.LuckyStar.Controllers
{
    [ApiController]
    [Area("LuckyStar")]
    public class AuthController: ParentAPI.Controllers.AuthController
    {
        private readonly IServiceManager _serviceManager;

        public AuthController(IServiceManager serviceManager):base(serviceManager)
        {
            Console.WriteLine("LuckyStar AuthController called");
            _serviceManager = serviceManager;
        }

        [HttpGet]
        //[Authorize]
        //[AllowAnonymous]
        public async Task<IActionResult> Test2()
        {
            await Task.CompletedTask;
            
            var a = await _serviceManager.CheckService.Check();

            var data = new { Name = "Test2", Age = a };
            return Json(data);
        }
    }
}

