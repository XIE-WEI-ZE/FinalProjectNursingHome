using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentPurchasingOrderDetail
{
    public int EquipmentPurchasingOrderDetailId { get; set; }

    public int? EquipmentPurchasingOrderId { get; set; }

    public int? EquipmentItemIds { get; set; }

    public int? EquipmentCategoryId { get; set; }
}
