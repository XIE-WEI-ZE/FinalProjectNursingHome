using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityAuditLog
{
    public int LogId { get; set; }

    public int AdminId { get; set; }

    public string ActionType { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public int ContentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Details { get; set; }
}
