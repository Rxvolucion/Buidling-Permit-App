using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPermitDao
    {
        public Permit GetPermitById(int permitId);
        public Permit CreatePermit(Permit permit);
        public List<Permit> ListPermits();
        public List<Permit> GetPermitsByCustomerId(int customerId);
<<<<<<< HEAD
       
       // public List<string> GetPermitStatuses();
=======
        //public List<string> GetPermitStatuses();
>>>>>>> 7ecb690ffc9f2596866425da4348c7978e46d5ef

    }
}

