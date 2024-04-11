using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IInspectionDao
    {
        public List<InspectionStatusType> GetInspectionStatusTypes();
        public List<InspectionType> GetAllInspectionTypes();
        public IList<string> GetSpecificInspectionTypes();
        public Inspection CreateInspection(Inspection inspection);
        public Inspection GetInspectionById(int inspectionId);
        public InspectionType GetInspectionIdByType(string inspectionType);

        public List<InspectionDetailsDTO> GetAllInspections();
        public Inspection UpdateInspection(InspectionDetailsDTO inspectionDTO);

        //public Inspection UpdateInspectionStatus(Inspection updatedInspection);
        public int GetStatusTypeIdByType(string inspectionStatus);
    }

}
