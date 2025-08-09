using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityPost
{
    public int PostId { get; set; }

    public int MemberId { get; set; }

    public int BoardId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? QuotePostId { get; set; }

    public int? ParentPostId { get; set; }

    public bool IsPinned { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string PostStatus { get; set; } = null!;
}
