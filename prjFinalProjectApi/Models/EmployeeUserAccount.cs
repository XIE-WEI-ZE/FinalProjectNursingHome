using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EmployeeUserAccount
{
    public int UserAccountId { get; set; }

    public int? EmployeeId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLoginTime { get; set; }

    public int? LoginFailCount { get; set; }

    public DateTime? LockedUntil { get; set; }
}
