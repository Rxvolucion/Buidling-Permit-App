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

    public class ReportController : ControllerBase
    {
        private readonly IReportDao reportDao;


        public ReportController(IReportDao reportDao)
        {
            this.reportDao = reportDao;
        }

        //GET /Reports
        [HttpGet("active_permits")]
        public ActionResult<List<Permit>> GetActivePermits()
        {
            return Ok(reportDao.GetAllOpenPermits());
        }

    }
}
