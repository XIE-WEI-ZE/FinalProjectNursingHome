using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesPurchasingOrder
{
    public int SuppliesPurchasingOrderId { get; set; }

    public int? SuppliesSupplierId { get; set; }

    public DateOnly? ArrivalDate { get; set; }
}
