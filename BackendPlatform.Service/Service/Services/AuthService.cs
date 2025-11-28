using BackendPlatform.Service.Core.API.Interfaces;
using BackendPlatform.Service.DTOs;
using BackendPlatform.Service.Models;
using BackendPlatform.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SelfInterface = BackendPlatform.Service.Repository.Interfaces;

namespace BackendPlatform.Service.Service.Services
{
    public record ProductDto(string Name, decimal Price);

    public record class UserDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class AuthService : IAuthService
    {
        protected readonly SelfInterface.IRepositoryManagerBase _repoManager;
        protected readonly IThirdPartyAPIManager _apiManager;

        public AuthService(
            SelfInterface.IRepositoryManagerBase repoManager,
            IThirdPartyAPIManager apiManager)
        {
            _repoManager = repoManager;
            _apiManager = apiManager;
        }

        public virtual async Task<ServiceResponseModel> Login(LoginRequest request)
        {
            var p = new UserDto();
            p.Age = 12;

            var result = await _apiManager.W1Sevice.GetBetDetail("VGDRINSECT_244569_VG0450002741763372837272A", "BTG", "zh-TW", "2025-11-17 17:47:17", "");
            Console.WriteLine($"W1:{result}");

            await this._repoManager.AuthRepository.Login();

            //Console.Write(JsonSerializer.Serialize(request));

            var dan = new Emp { Id = 22, Dept = "IT" };
            return await Task.FromResult(new ServiceResponseModel<Emp>() { Code = 0, Data = dan });
        }

        protected virtual async Task Step2()
        {
            await Task.CompletedTask;
        }
    }
}
