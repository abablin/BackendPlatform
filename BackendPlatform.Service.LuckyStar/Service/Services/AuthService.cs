using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendPlatform.Service.DTOs;
using BackendPlatform.Service.Models;
using BackendPlatform.Service.LuckyStar.Service.Interfaces;
using ParentService = BackendPlatform.Service.Service.Services;
using SelfServiceInterface = BackendPlatform.Service.LuckyStar.Service.Interfaces;
using SelfInterface = BackendPlatform.Service.LuckyStar.Repository.Interfaces;
using BackendPlatform.Service.Core.API.Interfaces;

namespace BackendPlatform.Service.LuckyStar.Service.Services
{
    public class AuthService : ParentService.AuthService, SelfServiceInterface.IAuthService
    {
        private readonly SelfInterface.IRepositoryManager _repoManager;

        public AuthService(
            SelfInterface.IRepositoryManager repoManager,
            IThirdPartyAPIManager apiManager) : base(repoManager, apiManager)
        {
            _repoManager = repoManager;
        }

        public async Task RunMyMethod()
        {
            await Task.CompletedTask;
            Console.WriteLine("Run My Method...........");
        }

        public override async Task<ServiceResponseModel> Login(LoginRequest request)
        {
            await RunMyMethod();
            return await Task.FromResult(new ServiceResponseModel { Code = 12, Message = "AA" });
        }

        //public override async Task<parent.Interfaces.TestModel> Test()
        //{
        //    await this.RunMyMethod();
        //    return Task.FromResult(new  { Id = 12, Desc = "Test" });
        //}

        protected override async Task Step2()
        {
            await Task.CompletedTask;
        }
    }
}
