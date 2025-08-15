using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesSalesOrderDetail
{
    public int SuppliesSalesOrderDetailId { get; set; }

    public int? SuppliesSalesOrderId { get; set; }

    public int? SuppliesProductId { get; set; }

    public int? QuantityOfSales { get; set; }

    public DateOnly? ExpiryDate { get; set; }
}
