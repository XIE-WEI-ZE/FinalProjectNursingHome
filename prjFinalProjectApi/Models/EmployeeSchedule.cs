using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeSchedule
{
    public int ScheduleId { get; set; }

    public string? ScheduleName { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? WorkDays { get; set; }
}
