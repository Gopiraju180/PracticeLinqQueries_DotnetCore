using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_DbConnect;

public partial class CustomerAndSuppliersByCity
{
    public string? City { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string Relationship { get; set; } = null!;
}
