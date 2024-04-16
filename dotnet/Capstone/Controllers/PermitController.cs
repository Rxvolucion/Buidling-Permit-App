using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;


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

        //[HttpPut("active/{permitId}")]
        //public ActionResult<int> OpenClosePermit(int permitId)
        //{
        //    int newPermitId = permitDao.OpenClosePermit(permitId);
        //    if (newPermitId == 0)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(newPermitId);
        //    }

        //}

        [HttpPut("active/{permitId}")]
        public ActionResult<int> OpenClosePermit(int permitId)
        {
            int newPermitId = permitDao.OpenClosePermit(permitId);
            string active = "Closed";
            if (newPermitId == 1) 
            {
                active = "Open";
            }
            if (newPermitId == 0)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    // Get customer email from permitDao or some other method
                    string customerEmail = userDao.GetUserEmailByUserPermitId(permitId); // Get customer email here

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("kpjpermitmanager@outlook.com"),
                        Subject = "Permit Status Update",
                        Body = $"Your permit now has a status of {active}.",
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(customerEmail);

                    using (var smtpClient = new SmtpClient("smtp.outlook.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential("kpjpermitmanager@outlook.com", "kpjpermit123");

                        smtpClient.Send(mailMessage);
                    }
                }
                catch (Exception ex)
                {
                    // Handle email sending error
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, "Failed to send email.");
                }

                return Ok(newPermitId);
            }

        }

        [HttpPut("edit-permit/{permitId}")]
        public ActionResult<Permit> UpdatePermitCustomer(PermitCustomerEditDTO updatedPermitDTO, int permitId)
        {
            Permit newPermit = permitDao.UpdatePermitCustomer(updatedPermitDTO);
            if (newPermit == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newPermit);
            }
        }

        //[HttpPut("{permitId}")]
        //public ActionResult<Permit> ChangeInspection(PermitStatusDTO changedPermit, int permitId)
        //{
        //    Permit newPermit = permitDao.UpdatePermit(changedPermit);
        //    if (newPermit == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Ok(newPermit);
        //    }
        //}
        //---------ADDED---------------------------------------
        [HttpPut("{permitId}")]
        public ActionResult<Permit> ChangeInspection(PermitStatusDTO changedPermit, int permitId, int userId)
        {
            Permit newPermit = permitDao.UpdatePermit(changedPermit);
            if (newPermit == null)
            {
                return BadRequest();
            }
            else
            {
                // Send email to customer
                try
                {
                    // Get customer email from permitDao or some other method
                    string customerEmail = userDao.GetUserEmailByUserPermitId(changedPermit.PermitId); // Get customer email here

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("kpjpermitmanager@outlook.com"),
                        Subject = "Permit Status Update",
                        Body = $"Your permit status has been updated to {newPermit.PermitStatus}.",
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(customerEmail);

                    using (var smtpClient = new SmtpClient("smtp.outlook.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential("kpjpermitmanager@outlook.com", "kpjpermit123");

                        smtpClient.Send(mailMessage);
                    }
                }
                catch (Exception ex)
                {
                    // Handle email sending error
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, "Failed to send email.");
                }

                return Ok(newPermit);
            }
        }
        //----------------ADDED---------------------------------------------------------------------------------



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

        [HttpGet("inspections")]
        public ActionResult<List<PermitIdInspectionIdDTO>> GetPermitsAndInspections()
        {
            return Ok(permitDao.GetAllInspectionsAndPermits());
        }

        [HttpGet("customer/{customrId}")]
        public ActionResult<List<Permit>> GetPermitsByCustomerId()
        {

            string result = User.Identity.Name;
            User user = userDao.GetUserByUsername(result);
            Customer me = userDao.GetCustomerByUserId(user.UserId);
            return Ok(permitDao.GetPermitsByCustomerId(me.CustomerId));
        }

        [HttpGet("archive")]
        public ActionResult<List<PermitArchiveDTO>> GetAllInactivePermitsAndInspections()
        {
            return Ok(permitDao.GetAllInactivePermitsAndInspections());
        }
    }
}
