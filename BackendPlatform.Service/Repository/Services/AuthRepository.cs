using BackendPlatform.Service.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.Repository.Services
{
    public class AuthRepository : RepositoryBase, IAuthRepository
    {
        public virtual async Task<bool> Login()
        {
            Console.WriteLine("Base AuthRepository called");

            return await Task.FromResult(true);
        }
    }
}
