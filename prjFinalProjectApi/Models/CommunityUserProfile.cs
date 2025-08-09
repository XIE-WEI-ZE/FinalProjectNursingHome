using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityUserProfile
{
    public int MemberId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string? ProfileBio { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public DateTime LastUpdatedAt { get; set; }
}
