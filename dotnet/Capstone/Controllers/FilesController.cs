using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class FilesController : ControllerBase
    {
        private readonly IFilesDao filesDao;

        public FilesController(IFilesDao filesDao)
        {
            this.filesDao = filesDao;
        }

        [HttpPost("3001/upload")]
        public IActionResult UploadUrl([FromBody] Files fileURL)
        {
            try
            {
                filesDao.InsertFileURLs(fileURL.InspectionURLs);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return StatusCode(500, "An error occurred while inserting the URL into the database.");
            }
        }
    }
}
