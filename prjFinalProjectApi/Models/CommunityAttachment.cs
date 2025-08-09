using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityAttachment
{
    public int AttachmentId { get; set; }

    public int? PostId { get; set; }

    public int? ReplyId { get; set; }

    public string AttachmentUrl { get; set; } = null!;
}
