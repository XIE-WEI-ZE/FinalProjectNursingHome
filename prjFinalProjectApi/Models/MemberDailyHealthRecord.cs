using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class MemberDailyHealthRecord
{
    public int FId { get; set; }

    public int? FMemberId { get; set; }

    public DateOnly? FRecordDate { get; set; }

    public int? FSystolic { get; set; }

    public int? FDiastolic { get; set; }

    public int? FPulse { get; set; }

    public string? FIorecord { get; set; }

    public string? FCheckPeriod { get; set; }

    public string? FNotes { get; set; }

    public DateTime? FCreatedAt { get; set; }
}
