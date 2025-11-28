using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentService = BackendPlatform.Service.Repository.Services;
using SelfInterface = BackendPlatform.Service.FullRich.Repository.Interfaces;

namespace BackendPlatform.Service.FullRich.Repository.Services
{
    public class AuthRepository: ParentService.AuthRepository, SelfInterface.IAuthRepository
    {
        public override async Task<bool> Login()
        {
            Console.WriteLine("FullRich AuthRepository called....");

            return await Task.FromResult(true);
            //return base.Login();
        }
    }
}
