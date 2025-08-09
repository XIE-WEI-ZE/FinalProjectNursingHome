using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class RoomBed
{
    public int FBedId { get; set; }

    public int FRoomId { get; set; }

    public string? FBedCode { get; set; }

    public bool? FBedStatus { get; set; }

    public virtual RoomTable FRoom { get; set; } = null!;

    public virtual ICollection<RoomOccupancy> RoomOccupancies { get; set; } = new List<RoomOccupancy>();
}
