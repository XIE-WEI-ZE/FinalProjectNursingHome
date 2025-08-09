using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityChatRoomMember
{
    public int RoomId { get; set; }

    public int MemberId { get; set; }

    public DateTime JoinedAt { get; set; }
}
