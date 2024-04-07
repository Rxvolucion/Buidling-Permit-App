
using System.Diagnostics.Eventing.Reader;

namespace Capstone.Models
{
    public class Permit
    {
        public int PermitId { get; set; }
        public bool Active { get; set; }
        public int CustomerId { get; set; }
        public string PermitAddress { get; set; }
        public string PermitType { get; set; }
        public bool Commercial { get; set; }

    }
}

