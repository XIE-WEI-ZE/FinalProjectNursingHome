using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class MemberMedicalHistory
{
    public int FId { get; set; }

    public int? FMemberId { get; set; }

    public string? FDiseaseName { get; set; }

    public DateOnly? FDiagnosedDate { get; set; }

    public string? FNotes { get; set; }

    public DateTime? FCreatedAt { get; set; }
}
