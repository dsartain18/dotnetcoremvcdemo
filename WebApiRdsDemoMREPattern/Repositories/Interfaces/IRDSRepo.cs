using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Entities.Entities;

namespace WebApplication2.Repositories.Interfaces
{
    public interface IRDSRepo
    {
        List<Users> GetUsers();
    }
}
