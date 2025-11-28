using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParentService = BackendPlatform.Service.Repository.Services;
using SelfInterface = BackendPlatform.Service.FullRich.Repository.Interfaces;

namespace BackendPlatform.Service.FullRich.Repository.Services
{
    public class ClubRepository : ParentService.ClubRepository, SelfInterface.IClubRepository
    {
    }
}
