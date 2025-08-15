using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeePasswordResetRequest
{
    public int RequestId { get; set; }

    public string? Username { get; set; }

    public string? Token { get; set; }

    public DateTime? RequestedTime { get; set; }

    public DateTime? ExpireTime { get; set; }

    public bool? IsUsed { get; set; }
}
