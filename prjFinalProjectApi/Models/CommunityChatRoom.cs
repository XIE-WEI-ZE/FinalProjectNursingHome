using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityChatRoom
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public string RoomType { get; set; } = null!;

    public int CreatorMemberId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string RoomStatus { get; set; } = null!;
}
