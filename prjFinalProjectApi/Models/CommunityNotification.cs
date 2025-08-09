using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CommunityNotification
{
    public int NotificationId { get; set; }

    public int ReceiverMemberId { get; set; }

    public int? SenderMemberId { get; set; }

    public string NotificationsType { get; set; } = null!;

    public string? NotificationsUrl { get; set; }

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }
}
