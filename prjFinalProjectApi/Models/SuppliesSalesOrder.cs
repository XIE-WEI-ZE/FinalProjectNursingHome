using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesSalesOrder
{
    public int SuppliesSalesOrderId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? CustomerName { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public string? OrderStatus { get; set; }
}
