using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EventStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public string? EventCategory { get; set; }
}
