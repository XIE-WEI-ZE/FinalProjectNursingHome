using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentItem
{
    public int EquipmentItemId { get; set; }

    public string? EquipmentItemName { get; set; }

    public DateOnly? Lifespan { get; set; }

    public int? EquipmentSupplierId { get; set; }

    public DateOnly? LastMaintenanceDate { get; set; }

    public int? EquipmentCategoryId { get; set; }

    public string? EquipmentStatus { get; set; }
}
