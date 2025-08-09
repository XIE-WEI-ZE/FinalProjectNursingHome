using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EquipmentRentList
{
    public int EquipmentRentListId { get; set; }

    public DateOnly? RentDate { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerGui { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public bool? Status { get; set; }
}
