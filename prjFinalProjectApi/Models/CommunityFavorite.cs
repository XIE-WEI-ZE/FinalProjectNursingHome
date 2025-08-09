using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityFavorite
{
    public int FavoriteId { get; set; }

    public int MemberId { get; set; }

    public int PostId { get; set; }

    public DateTime CreatedAt { get; set; }
}
