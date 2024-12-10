using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_DbConnect;

public partial class Department
{
    public long Id { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<Employee1> Employee1s { get; set; } = new List<Employee1>();
}
