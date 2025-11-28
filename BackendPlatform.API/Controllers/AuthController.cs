using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BackendPlatform.API.DTOs;
using BackendPlatform.Service.DTOs;
using BackendPlatform.Service.Service.Interfaces;
using Mapster;

namespace BackendPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        //private readonly ILogger<AuthController> _logger;
        private readonly IServiceManagerBase _serviceManager;

        public AuthController(IServiceManagerBase serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<IActionResult> Login(
            [FromBody] LoginRequest request)
        {
            // 1. DTO 欄位資料準備
            // 2. 呼叫 Service
            // 3. 產生 Token
            // 4. 寫入 DB
            // 5. 產生回應物件
            // Service_LoginRequest

            //var serviceDto = request.Adapt<LoginRequest>(); //ObjectMapper.Mapper.Map<Service_LoginRequest>(request);
            return Json(await _serviceManager.AuthService.Login(request));
        }
    }
}
