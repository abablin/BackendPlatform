using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.Repository.Interfaces
{
    public interface IClubRepository
    {
        Task<int> Insert();
    }
}
