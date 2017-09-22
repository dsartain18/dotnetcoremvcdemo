using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities.Entities;
using WebApplication2.Managers.Interfaces;
using WebApplication2.Repositories.Interfaces;

namespace WebApplication2.Managers.Managers
{
    public class RDSManager : IRDSManager
    {
        private readonly IRDSRepo _rdsRepo;

        public RDSManager(IRDSRepo rdsRepo)
        {
            if (rdsRepo == null)
            {
                throw new ArgumentNullException("rdsRepo");
            }

            _rdsRepo = rdsRepo;
        }

        public List<Users> GetUsers()
        {
            return _rdsRepo.GetUsers();
        }
    }
}
