using System;
using System.Collections.Generic;

namespace EF_CRUD.Models;

public partial class DeptLocation
{
    public int DeptId { get; set; }

    public string Location { get; set; } = null!;

    public virtual Department Dept { get; set; } = null!;
}
