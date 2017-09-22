using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities.Entities;
using WebApplication2.Repositories.Interfaces;

namespace WebApplication2.Repositories.Repositories
{
    public class RDSRepo : IRDSRepo
    {
        private readonly TESTContext _context;

        public RDSRepo(TESTContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public List<Users> GetUsers()
        {
            return _context.Users.FromSql("usp_GetUsers").ToList();
        }
    }
}
