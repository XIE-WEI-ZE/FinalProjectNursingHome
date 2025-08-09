using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityReportedContent
{
    public int ReportedContentId { get; set; }

    public string ReportedContentType { get; set; } = null!;

    public int? PostId { get; set; }

    public int? ReplyId { get; set; }

    public int? OtherId { get; set; }

    public DateTime CreatedAt { get; set; }
}
