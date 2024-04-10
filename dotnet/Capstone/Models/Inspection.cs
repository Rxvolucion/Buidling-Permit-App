namespace Capstone.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Inspection
{
    public int InspectionId { get; set; }
    public int InspectionStatusTypeId { get; set; } = 6001;
    public int PermitId { get; set; }
    public int InspectionTypeId { get; set; }

    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateTime DateVariable { get; set; }
}

public class InspectionStatusType
{
    public int InspectionStatusTypeId { get; set; }
    public string StatusType {get; set;}
}

public class InspectionType
{
    public int InspectionTypeId { get; set; }
    public string Type { get; set; }
}

public class InspectionDTO
{
    public int PermitId { get; set; }
    public int InspectionStatusTypeId { get; set; } = 6001;
    public string InspectionType { get; set; }

    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateTime DateVariable { get; set; }
}
