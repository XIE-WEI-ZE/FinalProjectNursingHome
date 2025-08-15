using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityReport
{
    public int ReportId { get; set; }

    public int ReportMemberId { get; set; }

    public string TargetType { get; set; } = null!;

    public int TargetMemberId { get; set; }

    public int ReportedContentId { get; set; }

    public string ReasonType { get; set; } = null!;

    public DateTime ReportedAt { get; set; }

    public string ReportStatus { get; set; } = null!;

    public int? HandledEmployeeId { get; set; }

    public DateTime? HandledAt { get; set; }

    public string? Result { get; set; }
}
