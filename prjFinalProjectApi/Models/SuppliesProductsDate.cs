using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesProductsDate
{
    public int SuppliesProductsDateId { get; set; }

    public int? SuppliesProductId { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public int? RemainingStocks { get; set; }

    public bool? StocksStatus { get; set; }
}
