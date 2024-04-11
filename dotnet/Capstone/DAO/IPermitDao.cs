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
       
       // public List<string> GetPermitStatuses();


    }
}

