using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityFollow
{
    public int FollowerId { get; set; }

    public int FollowingId { get; set; }

    public DateTime FollowedAt { get; set; }
}
