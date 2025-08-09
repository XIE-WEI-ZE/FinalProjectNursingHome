using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeApprovalLog
{
    public int ApprovalId { get; set; }

    public string? FormType { get; set; }

    public int? FormId { get; set; }

    public int? StepNumber { get; set; }

    public string? StepName { get; set; }

    public int? ApproverId { get; set; }

    public string? ApproveStatus { get; set; }

    public string? ApproveComment { get; set; }

    public DateTime? ApproveDate { get; set; }

    public bool? IsFinalStep { get; set; }
}
