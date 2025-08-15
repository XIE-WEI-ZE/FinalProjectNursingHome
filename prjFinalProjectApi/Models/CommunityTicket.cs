using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityTicket
{
    public int TicketId { get; set; }

    public int MemberId { get; set; }

    public string Title { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string TicketsPriority { get; set; } = null!;

    public string TicketsStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public int? HandlerEmployeeId { get; set; }
}
