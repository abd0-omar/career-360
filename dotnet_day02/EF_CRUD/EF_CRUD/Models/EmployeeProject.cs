using System;
using System.Collections.Generic;

namespace EF_CRUD.Models;

public partial class EmployeeProject
{
    public int Essn { get; set; }

    public int ProjNo { get; set; }

    public int Hours { get; set; }

    public virtual Employee EssnNavigation { get; set; } = null!;

    public virtual Project ProjNoNavigation { get; set; } = null!;
}
