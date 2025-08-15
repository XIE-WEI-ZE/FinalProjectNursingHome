using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesPurchasingOrderDetail
{
    public int SuppliesPurchasingOrderDetailId { get; set; }

    public int? SuppliesPurchasingOrderId { get; set; }

    public int? QuantityIn { get; set; }

    public DateOnly? ExpiryDate { get; set; }
}
