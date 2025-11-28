using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.API.LuckyStar.Controllers
{
    [ApiController]
    [Area("LuckyStar")]
    [Route("api/[controller]")]
    public class ClubController: Controller
    {
        [HttpGet]        
        public async Task<IActionResult> Test()
        {
            await Task.CompletedTask;
            return Json(new { Address = "No57", Title = "Changhua" });
        }
    }
}
