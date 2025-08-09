using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeLoginLog
{
    public int LogId { get; set; }

    public string? Username { get; set; }

    public DateTime? LoginTime { get; set; }

    public string? Ipaddress { get; set; }

    public bool? IsSuccess { get; set; }

    public string? DeviceInfo { get; set; }

    public string? FailReason { get; set; }
}
