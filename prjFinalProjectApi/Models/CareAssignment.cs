using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class CareAssignment
{
    public int AssignmentId { get; set; }

    public int? RequestId { get; set; }

    public int? CaregiverId { get; set; }

    public DateTime? AssignedTime { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? Eta { get; set; }

    public bool? IsCompleted { get; set; }
}
