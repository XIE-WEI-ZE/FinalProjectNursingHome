using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class EventPaymentDetail
{
    public int RegistrationId { get; set; }

    public DateOnly LinePayTime { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentItem { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public string? InvoiceType { get; set; }

    public string? InvoiceTitle { get; set; }

    public string? TaxId { get; set; }

    public string? EinvoiceCarrier { get; set; }

    public int Status { get; set; }

    public string? TransactionId { get; set; }
}
