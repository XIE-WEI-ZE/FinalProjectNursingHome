using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class ShopOrder
{
    public long OrderId { get; set; }

    public string? CustomerId { get; set; }

    public int? FMemberId { get; set; }

    public string? EmployeeId { get; set; }

    public DateTime OrderTime { get; set; }

    public string BuyerName { get; set; } = null!;

    public string ReceiverName { get; set; } = null!;

    public string ReceiverPhone { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string DeliveryMethod { get; set; } = null!;

    public string DeliveryAddress { get; set; } = null!;

    public string? InvoiceTitle { get; set; }

    public string? InvoiceTax { get; set; }

    public string? InvoiceInMethod { get; set; }

    public string? Note { get; set; }

    public int? TotalAmount { get; set; }

    public string? CarrierNumber { get; set; }

    public string? OrderNo { get; set; }

    public string? Status { get; set; }
}
