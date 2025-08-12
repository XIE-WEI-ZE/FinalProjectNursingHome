using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class MemberEmergencyContact
{
    public int FId { get; set; }

    public int? FMemberId { get; set; }

    public string? FContactName { get; set; }

    public string? FRelationship { get; set; }

    public string? FPhone { get; set; }

    public string? FEmail { get; set; }

    public string? FCity { get; set; }

    public string? FDistrict { get; set; }

    public string? FAddress { get; set; }

    public bool? FIsPrimary { get; set; }

    public bool? FIsActive { get; set; }

    public string? FNotes { get; set; }

    public DateTime? FCreatedAt { get; set; }

    public DateTime? FUpdatedAt { get; set; }
}
