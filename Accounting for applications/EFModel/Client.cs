using System;
using System.Collections.Generic;

namespace dem04.EFModel;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Number { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
