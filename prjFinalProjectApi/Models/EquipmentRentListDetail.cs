using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentRentListDetail
{
    public int EquipmentRentListDetailId { get; set; }

    public int? EquipmentRentListId { get; set; }

    public int? EquipmentItemId { get; set; }
}
