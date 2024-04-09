using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{inspection_status_type_id}")]
        public ActionResult<InspectionStatusType> GetInspectionStatusTypes()
        {
        
            return Ok(inspectionDao.GetInspectionStatusTypes());

        }
    }
}
