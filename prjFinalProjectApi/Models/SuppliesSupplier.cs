using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class SuppliesSupplier
{
    public int SuppliesSupplierId { get; set; }

    public string? SuppliesSupplierName { get; set; }

    public string? SuppliesSupplierGui { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactNumber { get; set; }

    public string? Address { get; set; }

    public string? SupplierKeyword { get; set; }

    public bool? Continued { get; set; }
}
