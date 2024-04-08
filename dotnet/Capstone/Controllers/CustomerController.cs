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

    public class CustomerController : ControllerBase
    {
        private readonly IUserDao userDao;

        public CustomerController(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        [HttpPost()]
        public ActionResult<Customer> CreateCustomer(Customer customerDTO)
        {
            // Default generic error message
            const string ErrorMessage = "An error occurred and customer was not created.";

            IActionResult result = BadRequest(new { message = ErrorMessage });


            Customer newCustomer;
            string thisUser = User.Identity.Name;
            //User user = userDao.GetUserByUsername(thisUser);
            try
            {

                newCustomer = userDao.CreateCustomer(customerDTO.UserId, customerDTO.Contractor, customerDTO.Address);
            }
            catch (DaoException)
            {
                return StatusCode(500, ErrorMessage);
            }
            return Created("/customer", newCustomer);
            
        }
    }
}
