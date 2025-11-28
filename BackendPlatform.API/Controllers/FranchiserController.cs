using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
//using BackendPlatform.Service.Interfaces;

namespace BackendPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FranchiserController: Controller
    {
        [HttpGet]
        public virtual async Task<IActionResult> Test()
        {
            await Task.CompletedTask;
            await Method1();

            return Json(new { Name = "H1 Franchiser", Id = 1 });
        }

        protected virtual async Task Method1()
        {
            await Task.CompletedTask;
        }
    }
}
