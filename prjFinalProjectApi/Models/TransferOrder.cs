using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class TransferOrder
{
    public int TransferOrderId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? TransferDate { get; set; }

    public string? OrderStatus { get; set; }
}
