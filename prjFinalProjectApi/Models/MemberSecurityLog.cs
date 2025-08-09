using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class MemberSecurityLog
{
    public int FId { get; set; }

    public int? FMemberId { get; set; }

    public string? FEventType { get; set; }

    public string? FNotes { get; set; }

    public string? FIpAddress { get; set; }

    public DateTime? FCreatedAt { get; set; }
}
