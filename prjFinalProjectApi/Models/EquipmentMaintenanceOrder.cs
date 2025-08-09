using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentMaintenanceOrder
{
    public int EquipmentMaintenanceOrderId { get; set; }

    public int? EquipmentItemId { get; set; }

    public DateOnly? MaintenanceDate { get; set; }
}
