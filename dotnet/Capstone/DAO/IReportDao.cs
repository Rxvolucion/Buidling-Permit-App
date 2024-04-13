using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IReportDao
    {
        public int GetAllOpenPermits();
        public int GetAllClosedPermits();
        public int GetAllPendingPermits();
        public int GetAllInspectionsPassed();
        public int GetAllInspectionsFailed();
    }
}

