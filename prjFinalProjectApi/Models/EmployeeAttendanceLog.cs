using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeAttendanceLog
{
    public int AttendanceId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly? WorkDate { get; set; }

    public DateTime? ClockInTime { get; set; }

    public DateTime? ClockOutTime { get; set; }

    public string? Status { get; set; }
}
