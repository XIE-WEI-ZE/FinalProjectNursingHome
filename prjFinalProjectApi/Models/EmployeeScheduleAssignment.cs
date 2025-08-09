using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeScheduleAssignment
{
    public int EmployeeScheduleId { get; set; }

    public int? EmployeeId { get; set; }

    public int? ScheduleId { get; set; }

    public DateOnly? EffectiveDate { get; set; }
}
