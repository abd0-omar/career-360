using System;
using System.Collections.Generic;

namespace EF_CRUD.Models;

public partial class Employee
{
    public int Ssn { get; set; }

    public string Fname { get; set; } = null!;

    public string? Lname { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string Sex { get; set; } = null!;

    public decimal Salary { get; set; }

    public int? SuperSsn { get; set; }

    public int? DeptId { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    public virtual Department? Dept { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<Employee> InverseSuperSsnNavigation { get; set; } = new List<Employee>();

    public virtual Employee? SuperSsnNavigation { get; set; }
}
