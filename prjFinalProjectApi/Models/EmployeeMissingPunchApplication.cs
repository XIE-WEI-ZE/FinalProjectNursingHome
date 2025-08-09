using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeMissingPunchApplication
{
    public int ApplicationId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? WorkDate { get; set; }

    public string? MissingType { get; set; }

    public string? ApplyReason { get; set; }

    public DateTime? RequestedTime { get; set; }

    public string? Status { get; set; }

    public int? ApproverId { get; set; }

    public DateTime? ApplyDate { get; set; }

    public DateTime? ApprovedDate { get; set; }
}
