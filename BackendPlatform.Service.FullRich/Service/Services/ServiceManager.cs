using SelfService = BackendPlatform.Service.FullRich.Service.Services;
using SelfInterface = BackendPlatform.Service.FullRich.Service.Interfaces;
//using ParentInterface = BackendPlatform.Service.Interfaces;
using ParentInterface = BackendPlatform.Service.Service.Interfaces;
using BackendPlatform.Service.FullRich.Service.Interfaces;
using BackendPlatform.Service.Repository.Interfaces;
using BackendPlatform.Service.FullRich.Repository.Interfaces;
using BackendPlatform.Service.Core.API.Interfaces;

namespace BackendPlatform.Service.FullRich.Service.Services
{
    public sealed class ServiceManager : SelfInterface.IServiceManager
    {
        private readonly Lazy<ParentInterface.IAuthService> _authService;

        public ServiceManager(
            IRepositoryManager repoManager,
            IThirdPartyAPIManager apiManager)
        {
            _authService = new Lazy<ParentInterface.IAuthService>(() => new SelfService.AuthService(repoManager, apiManager));
        }

        public ParentInterface.IAuthService AuthService => _authService.Value;
    }
}
