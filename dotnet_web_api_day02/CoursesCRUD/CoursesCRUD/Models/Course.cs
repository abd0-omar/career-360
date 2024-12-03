using System;
using System.Collections.Generic;

namespace CoursesCRUD.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? CrsName { get; set; }

    public string? CrsDesc { get; set; }

    public int? Duration { get; set; }
}
