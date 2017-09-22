using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Managers.Interfaces;
using System.Net.Http;
using WebApplication2.Entities.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IRDSManager _rdsManager;

        public UsersController(IRDSManager rdsManager)
        {
            if (rdsManager == null)
            {
                throw new ArgumentNullException("rdsManager");
            }

            _rdsManager = rdsManager;
        }

        // GET: api/values
        [HttpGet]        
        public List<Users> Get()
        {
            List<Users> users = null;

            try
            {
                users = _rdsManager.GetUsers();
            }
            catch (Exception ex)
            {
                return null;
            }
            return users;
        }        

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
