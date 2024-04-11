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

        //[HttpGet("permit_status")]
        //public ActionResult<List<string>> GetPermitStatuses()
        //{
        //    return Ok(permitDao.GetPermitStatuses());
        //}




        //[HttpPut("{permitId}")]
        //public ActionResult<Inspection> ChangeInspection(PermitStatusDTO changedPermit, int permitId)
        //{
        //    Inspection newInspection = permitDao.UpdatePermit(changedPermit);
        //    if (newInspection == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(newInspection);
        //    }
        //}




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


        [HttpGet("customer/{customrId}")]
        public ActionResult<List<Permit>> GetPermitsByCustomerId()
        {

            string result = User.Identity.Name;
            User user = userDao.GetUserByUsername(result);
            Customer me = userDao.GetCustomerByUserId(user.UserId);
            return Ok(permitDao.GetPermitsByCustomerId(me.CustomerId));
        }
    }
}
