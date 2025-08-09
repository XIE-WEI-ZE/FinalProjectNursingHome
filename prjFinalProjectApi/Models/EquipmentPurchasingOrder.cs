using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentPurchasingOrder
{
    public int EquipmentPurchasingOrderId { get; set; }

    public int? EquipmentSupplierId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public string? Status { get; set; }
}
