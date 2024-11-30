using System;
using System.Collections.Generic;

namespace EF_CRUD.Models;

public partial class Project
{
    public int ProjId { get; set; }

    public string ProjName { get; set; } = null!;

    public string Plocation { get; set; } = null!;

    public int DeptId { get; set; }

    // one object here,  1 - M
    public virtual Department Dept { get; set; } = null!;

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}
