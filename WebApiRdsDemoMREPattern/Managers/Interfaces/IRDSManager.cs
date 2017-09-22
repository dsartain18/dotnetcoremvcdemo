using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Entities.Entities;

namespace WebApplication2.Managers.Interfaces
{
    public interface IRDSManager
    {
        List<Users> GetUsers();
    }
}
