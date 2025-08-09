using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EventPhoto
{
    public int PhotoId { get; set; }

    public int EventId { get; set; }

    public string PhotoPath { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }
}
