using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class Member
{
    public int FMemberId { get; set; }

    public string? FName { get; set; }

    public string? FPhone { get; set; }

    public string? FGender { get; set; }

    public DateOnly? FBirthDate { get; set; }

    public string? FIdNumber { get; set; }

    public decimal? FHeight { get; set; }

    public decimal? FWeight { get; set; }

    public bool? FResidesInCareHomeStatus { get; set; }

    public string? FAccount { get; set; }

    public string? FPasswordHash { get; set; }

    public string? FPasswordSalt { get; set; }

    public string? FEmail { get; set; }

    public string? FLoginProvider { get; set; }

    public string? FCity { get; set; }

    public string? FDistrict { get; set; }

    public string? FRoadAddress { get; set; }

    public int? FZip { get; set; }

    public string? FProfilePictureUrl { get; set; }

    public bool? FAccountStatus { get; set; }

    public string? FExternalId { get; set; }

    public DateTime? FCreatedAt { get; set; }
}
