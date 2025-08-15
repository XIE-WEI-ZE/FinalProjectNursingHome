using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityBoard
{
    public int BoardId { get; set; }

    public string BoardName { get; set; } = null!;

    public string? BoardDescription { get; set; }

    public int? ModeratorId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string BoardStatus { get; set; } = null!;
}
