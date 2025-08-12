using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeJobTitle
{
    public int JobTitleId { get; set; }

    public string? TitleName { get; set; }

    public int? DepartmentId { get; set; }
}
