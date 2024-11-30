using System;
using System.Collections.Generic;

namespace EF_CRUD.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public int MgrSsn { get; set; }

    public DateOnly? MgrHireDate { get; set; }

    public virtual ICollection<DeptLocation> DeptLocations { get; set; } = new List<DeptLocation>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Employee MgrSsnNavigation { get; set; } = null!;

    // collection here, 1 - M
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
