using System;
using System.Collections.Generic;

namespace dem04.EFModel;

public partial class Role
{
    public int Id { get; set; }

    public string Rolename { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
