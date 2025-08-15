using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentSupplier
{
    public int EquipmentSupplierId { get; set; }

    public string? EquipmentSupplierName { get; set; }

    public string? EquipmentSupplierGui { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactNumber { get; set; }

    public string? Address { get; set; }

    public string? SupplierKeyword { get; set; }

    public bool? Continued { get; set; }
}
