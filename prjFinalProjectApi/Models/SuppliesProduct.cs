using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesProduct
{
    public int SuppliesProductId { get; set; }

    public string? SuppliesProductName { get; set; }

    public string? QuantityPerUnit { get; set; }

    public int? UnitsInStock { get; set; }

    public int? PricePerUnit { get; set; }

    public int? SupplierId { get; set; }

    public int? SuppliesCategoryId { get; set; }

    public bool? Exist { get; set; }
}
