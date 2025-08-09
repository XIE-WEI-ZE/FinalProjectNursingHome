using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityMessage
{
    public int MessageId { get; set; }

    public int TicketId { get; set; }

    public string SenderType { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }
}
