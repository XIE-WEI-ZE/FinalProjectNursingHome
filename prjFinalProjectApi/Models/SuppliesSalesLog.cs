using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesSalesLog
{
    public int SuppliesSalesLogId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerGui { get; set; }
}
