using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityReply
{
    public int ReplyId { get; set; }

    public int MemberId { get; set; }

    public int? ParentReplyId { get; set; }

    public int PostId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string ReplieStatus { get; set; } = null!;
}
