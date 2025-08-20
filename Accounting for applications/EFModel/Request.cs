using System;
using System.Collections.Generic;

namespace dem04.EFModel;

public partial class Request
{
    public int Id { get; set; }

    public DateTime DateOfAccept { get; set; }

    public DateTime? DateOfWorkStart { get; set; }

    public DateTime? DateOfWorkEnd { get; set; }

    public string? RequestDescription { get; set; }

    public int RequestState { get; set; }

    public int Client { get; set; }

    public int Worker { get; set; }

    public int RequestPriority { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual RequestState RequestStateNavigation { get; set; } = null!;

    public virtual Worker WorkerNavigation { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
