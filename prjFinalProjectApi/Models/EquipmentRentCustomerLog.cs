using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentRentCustomerLog
{
    public int EquipmentRentCustomerLogId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerGui { get; set; }
}
