using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class RoomTable
{
    public int FRoomId { get; set; }

    public string? FRoomName { get; set; }

    public string? FRoomAlias { get; set; }

    public bool? FRoomType { get; set; }

    public int? FBedCount { get; set; }

    public string? FRoomDescription { get; set; }

    public int? FRoomPrice { get; set; }

    public virtual ICollection<RoomBed> RoomBeds { get; set; } = new List<RoomBed>();

    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();
}
