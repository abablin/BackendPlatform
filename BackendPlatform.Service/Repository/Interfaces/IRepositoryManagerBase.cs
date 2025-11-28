using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.Repository.Interfaces
{
    // 定義通用型的 Repository
    public interface IRepositoryManagerBase
    {
        IAuthRepository AuthRepository { get; }
        IClubRepository ClubRepository { get; }
    }
}
