using BackendPlatform.Service.DTOs;
using BackendPlatform.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Service.Service.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponseModel> Login(LoginRequest request);
    }

    public class TestModel
    {
        public int Id { get; set; }
        public string Desc { get; set; }
    }
}
