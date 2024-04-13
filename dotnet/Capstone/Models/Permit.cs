
using System.Diagnostics.Eventing.Reader;

namespace Capstone.Models
{
    public class Permit
    {
        public int PermitId { get; set; }
        public bool Active { get; set; } = true;
        public int CustomerId { get; set; }
        public string PermitAddress { get; set; }
        public string PermitType { get; set; }
        public bool Commercial { get; set; }
        public string PermitStatus { get; set; } = "Pending";
        public string CustomerDetails { get; set; }

    }

    public class PermitStatusDTO
    {
        public int PermitId { get; set; }
        public string PermitStatus { get; set; }
    }

    public class PermitIdInspectionIdDTO
    {
        public int PermitId { get; set; }
        public int InspectionId { get; set; }
    }
}

