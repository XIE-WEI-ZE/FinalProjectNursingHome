using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class RoomImage
{
    public int FRoomImageId { get; set; }

    public int FRoomId { get; set; }

    public string? ImagePath { get; set; }

    public virtual RoomTable FRoom { get; set; } = null!;
}
