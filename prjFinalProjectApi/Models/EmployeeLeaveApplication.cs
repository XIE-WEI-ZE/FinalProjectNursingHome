using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeLeaveApplication
{
    public int LeaveId { get; set; }

    public int? EmployeeId { get; set; }

    public int? LeaveTypeId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? LeaveHours { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public int? ApproverId { get; set; }

    public DateTime? ApplyDate { get; set; }

    public DateTime? ApprovedDate { get; set; }
}
