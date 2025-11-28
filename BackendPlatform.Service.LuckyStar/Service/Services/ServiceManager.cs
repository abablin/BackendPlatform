using ParentInterface = BackendPlatform.Service.Service.Interfaces;
using BackendPlatform.Service.Service.Interfaces;
using BackendPlatform.Service.LuckyStar.Service.Interfaces;
using SelfInterface = BackendPlatform.Service.LuckyStar.Service.Interfaces;
using SelfService = BackendPlatform.Service.LuckyStar.Service.Services;
using BackendPlatform.Service.LuckyStar.Repository.Interfaces;
using BackendPlatform.Service.Core.API.Interfaces;

namespace BackendPlatform.Service.LuckyStar.Service.Services
{
    public sealed class ServiceManager : SelfInterface.IServiceManager
    {
        private readonly Lazy<ParentInterface.IAuthService> _authService;
        private readonly Lazy<ICheckService> _checkService;

        public ServiceManager(IRepositoryManager repoManager, IThirdPartyAPIManager apiManager)
        {
            _authService = new Lazy<ParentInterface.IAuthService>(() => new SelfService.AuthService(repoManager, apiManager));
            _checkService = new Lazy<ICheckService>(() => new CheckService());
        }

        public ParentInterface.IAuthService AuthService => _authService.Value;
        public ICheckService CheckService => _checkService.Value;
    }
}
