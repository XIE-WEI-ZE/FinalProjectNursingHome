using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityInteraction
{
    public int InteractionId { get; set; }

    public int MemberId { get; set; }

    public string TargetType { get; set; } = null!;

    public int TargetId { get; set; }

    public string InteractionsType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
