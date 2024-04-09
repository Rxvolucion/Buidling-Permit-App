using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IInspectionDao
    {
        public List<InspectionStatusType> GetInspectionStatusTypes();
        public List<InspectionType> GetAllInspectionTypes();
    }

}
