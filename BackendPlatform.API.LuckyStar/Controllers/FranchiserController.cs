using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parent = BackendPlatform.API.Controllers;

namespace BackendPlatform.API.LuckyStar.Controllers
{
    [ApiController]
    [Area("LuckyStar")]
    public class FranchiserController: parent.FranchiserController
    {
        protected override async Task Method1()
        {
            await Task.CompletedTask;
            Console.WriteLine("LuckyStar Method1");
        }
    }
}

namespace BackendPlatform.API.FullRich.Controllers
{
    //[ApiController]
    //[Area("FullRich")]
    //public class FranchiserController : parent.FranchiserController
    //{
    //    protected override async Task Method1()
    //    {
    //        await Task.CompletedTask;
    //        Console.WriteLine("FullRich Method1");
    //    }
    //}
}
