using ParentInterface = BackendPlatform.Service.Repository.Interfaces;
using SelfService = BackendPlatform.Service.LuckyStar.Repository.Services;
using SelfInterface = BackendPlatform.Service.LuckyStar.Repository.Interfaces;

namespace BackendPlatform.Service.LuckyStar.Repository.Services
{
    public class RepositoryManager : SelfInterface.IRepositoryManager
    {
        private readonly Lazy<ParentInterface.IAuthRepository> _authRepository;
        private readonly Lazy<ParentInterface.IClubRepository> _clubRepository;

        public RepositoryManager()
        {
            //_authRepository = new Lazy<ParentInterface.IAuthRepository>(() =>new SelfService.AuthRepository());
            //_clubRepository = new Lazy<ParentInterface.IClubRepository>(() => new SelfService.ClubRepository());
        }

        public ParentInterface.IAuthRepository AuthRepository => _authRepository.Value;
        public ParentInterface.IClubRepository ClubRepository => _clubRepository.Value;
    }
}
