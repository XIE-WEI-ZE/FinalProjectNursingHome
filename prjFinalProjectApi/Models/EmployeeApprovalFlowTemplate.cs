using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeApprovalFlowTemplate
{
    public int FlowId { get; set; }

    public string? FormType { get; set; }

    public int? StepNumber { get; set; }

    public string? StepName { get; set; }

    public string? Role { get; set; }
}
