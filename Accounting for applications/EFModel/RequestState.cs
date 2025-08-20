using System;
using System.Collections.Generic;

namespace dem04.EFModel;

public partial class RequestState
{
    public int Id { get; set; }

    public string RequestState1 { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
