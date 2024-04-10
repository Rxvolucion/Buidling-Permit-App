using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class InspectionController : ControllerBase
    {
        private readonly IInspectionDao inspectionDao;

        public InspectionController(IInspectionDao inspectionDao)
        {
            this.inspectionDao = inspectionDao;
        }

        [HttpGet("status_type")]
        public ActionResult<InspectionStatusType> GetInspectionStatusTypes()
        {       
            return Ok(inspectionDao.GetInspectionStatusTypes());
        }

        [HttpGet("type")]
        public ActionResult<InspectionType> GetInspectionAllTypes()
        {

            return Ok(inspectionDao.GetAllInspectionTypes());

        }

        [HttpGet("types")]
        public ActionResult<InspectionType> GetInspectionSpecTypes()
        {

            return Ok(inspectionDao.GetSpecificInspectionTypes());

        }

        [HttpPost()]
        public ActionResult<Inspection> AddInspection(string inspectionType, int permitId, string address, DateTime dateVariable)
        {
            Inspection inspection = new Inspection();

            inspection.PermitId = permitId;
            inspection.Address = address;
            inspection.DateVariable = dateVariable;
            inspection.InspectionId = inspectionDao.GetInspectionIdByType(inspectionType).InspectionTypeId;
           
            Inspection newInspection = inspectionDao.CreateInspection(inspection);
            if (newInspection == null || newInspection.InspectionId == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newInspection);
            }


            //[HttpPost()]
            //public ActionResult<Inspection> AddInspection(Inspection inspection)
            //{
            //    Inspection newInspection = inspectionDao.CreateInspection(inspection);
            //    if (newInspection == null || newInspection.InspectionId == 0)
            //    {
            //        return BadRequest();
            //    }
            //    else
            //    {
            //        return Ok(newInspection);
            //    }

        }
    }
}
