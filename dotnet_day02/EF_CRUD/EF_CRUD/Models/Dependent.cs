using System;
using System.Collections.Generic;

namespace EF_CRUD.Models;

public partial class Dependent
{
    public int Essn { get; set; }

    public string Name { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public DateOnly? Bdate { get; set; }

    public string Relationship { get; set; } = null!;

    public virtual Employee EssnNavigation { get; set; } = null!;
}
