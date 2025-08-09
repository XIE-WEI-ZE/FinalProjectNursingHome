using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityChatMessage
{
    public int MessageId { get; set; }

    public int RoomId { get; set; }

    public int MemberId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }
}
