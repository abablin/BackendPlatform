using BackendPlatform.Service.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.Repository.Services
{
    public class ClubRepository : RepositoryBase, IClubRepository
    {
        public async Task<int> Insert()
        {
            return await Task.FromResult(1);
        }
    }
}
