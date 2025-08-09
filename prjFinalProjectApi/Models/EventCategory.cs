using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EventCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}
