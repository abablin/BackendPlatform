using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendPlatform.Service.FullRich.Service.Interfaces;
using ParentService = BackendPlatform.Service.Service.Services;
using ParentInterface = BackendPlatform.Service.FullRich.Service.Interfaces;
using SelfInterface = BackendPlatform.Service.FullRich.Repository.Interfaces;
using BackendPlatform.Core.Models;
using BackendPlatform.Service.Core.API.Interfaces;

namespace BackendPlatform.Service.FullRich.Service.Services
{
    public class AuthService : ParentService.AuthService, ParentInterface.IAuthService
    {
        private readonly SelfInterface.IRepositoryManager _repoManager;

        public AuthService(
            SelfInterface.IRepositoryManager repoManager,
            IThirdPartyAPIManager apiManager) :base(repoManager, apiManager)
        {
            Console.WriteLine($"FullRich AuthService called, {AppSettings.FullRich.Database.SQLServer.Default}");
            //Console.WriteLine($"FullRich AuthService called");
            _repoManager = repoManager;
        }

        //public Task AAA()
        //{
        //    throw new NotImplementedException();
        //}

        public Task AAA()
        {
            throw new NotImplementedException();
        }

        //public Task<ParentService.Interfaces.TestModel> Test()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
