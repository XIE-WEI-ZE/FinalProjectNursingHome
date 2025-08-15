using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class TransferOrderDetail
{
    public int TransferOrderDetailId { get; set; }

    public int? TransferOrderId { get; set; }

    public int? SuppliesProductId { get; set; }

    public int? QuantityOfTransfer { get; set; }

    public DateOnly? ExpiryDate { get; set; }
}
