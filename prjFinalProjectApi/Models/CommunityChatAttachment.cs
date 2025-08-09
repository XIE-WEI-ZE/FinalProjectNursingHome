using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityChatAttachment
{
    public int AttachmentId { get; set; }

    public int MessageId { get; set; }

    public string AttachmentType { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public string FileName { get; set; } = null!;
}
