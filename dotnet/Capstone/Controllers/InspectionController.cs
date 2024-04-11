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

        [HttpGet("{inspectionId}")]
        public ActionResult<Inspection> GetInspectionById(int inspectionId)
        {
            return Ok(inspectionDao.GetInspectionById(inspectionId));
        }

        [HttpGet()]
        public ActionResult<Inspection> GetAllInspections()
        {

            return Ok(inspectionDao.GetAllInspections());

        }

        [HttpPut("{inspectionId}")]
        public ActionResult<Inspection> ChangeInspection(InspectionDetailsDTO changedInspection, int inspectionId)
        {
            Inspection newInspection = inspectionDao.UpdateInspection(changedInspection);
            if (newInspection == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newInspection);
            }
        }

        //[HttpPut("{inspectionId}")]
        //public ActionResult<Inspection> ChangeInspectionStatus(Inspection changedInspection, int inspectionId)
        //{
        //    Inspection newInspection = inspectionDao.UpdateInspectionStatus(changedInspection);
        //    if (newInspection == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(newInspection);
        //    }
        //}

        [HttpPost()]
        public ActionResult<Inspection> AddInspection(InspectionDTO inspectDTO)
        {
            Inspection inspection = new Inspection();

            inspection.PermitId = inspectDTO.PermitId;
            inspection.DateVariable = inspectDTO.DateVariable;
            inspection.InspectionTypeId = inspectionDao.GetInspectionIdByType(inspectDTO.InspectionType).InspectionTypeId;
           
            Inspection newInspection = inspectionDao.CreateInspection(inspection);
            if (newInspection == null || newInspection.InspectionId == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newInspection);
            }


          

        }
    }
}
