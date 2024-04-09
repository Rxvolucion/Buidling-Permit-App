using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PermitController : ControllerBase
    {
        private readonly IPermitDao permitDao;
        private readonly IUserDao userDao;

        public PermitController(IPermitDao permitDao, IUserDao userDao)
        {
            this.permitDao = permitDao;
            this.userDao = userDao;
        }

        //GET /permit/3
        [HttpGet("{permitId}")]
        public ActionResult<List<Permit>> GetPermit(int permitId)
        {
            return Ok(permitDao.GetPermitById(permitId));
        }


        //POST /permit
        [HttpPost()]
        public ActionResult<Permit> AddPermit(Permit permit)
        {
            Permit newPermit = permitDao.CreatePermit(permit);
            if (newPermit == null || newPermit.PermitId == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newPermit);
            }

        }

        //Get/permits
        [HttpGet()]
        public ActionResult<List<Permit>> GetPermits()
        {
            return Ok(permitDao.ListPermits());
        }
        
        [HttpGet("customer/{userId}")]
        public ActionResult<List<Permit>> GetPermitsByUserId()
        {
            string result = User.Identity.Name;
            User me = userDao.GetUserByUsername(result);
            return Ok(permitDao.GetPermitsByUserId(me.UserId));
        }
    }
}
