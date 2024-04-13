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

        //GET /Report count for active permits
        [HttpGet("active_permits")]
        public ActionResult<List<Permit>> GetActivePermits()
        {
            return Ok(reportDao.GetAllOpenPermits());
        }

        //GET /Report count for closed permits
        [HttpGet("closed_permits")]
        public ActionResult<List<Permit>> GetAllClosedPermits()
        {
            return Ok(reportDao.GetAllClosedPermits());
        }

        //GET /Report count for pending permits
        [HttpGet("pending_inspections")]
        public ActionResult<List<Permit>> GetAllPendingPermits()
        {
            return Ok(reportDao.GetAllPendingInspections());

        }

        //GET /Report count for passed inspections
        [HttpGet("inspection_passed")]
        public ActionResult<List<Permit>> GetAllInspectionsPassed()
        {
            return Ok(reportDao.GetAllInspectionsPassed());

        }

        //GET /Report count for failed inspections
        [HttpGet("inspection_failed")]
        public ActionResult<List<Permit>> GetAllInspectionsFailed()
        {
            return Ok(reportDao.GetAllInspectionsFailed());

        }

    }
}