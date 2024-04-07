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

        public PermitController(IPermitDao permitDao)
        {
            this.permitDao = permitDao;
        }

        //GET /pet/3
        [HttpGet("{permitId}")]
        public ActionResult<List<Permit>> GetPermit(int permitId)
        {
            return Ok(permitDao.GetPermitById(permitId));
        }


        //POST /pet
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
    }
}
