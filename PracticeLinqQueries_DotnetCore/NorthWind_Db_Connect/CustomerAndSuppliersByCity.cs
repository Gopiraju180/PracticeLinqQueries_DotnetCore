using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_Db_Connect;

public partial class CustomerAndSuppliersByCity
{
    public string? City { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string Relationship { get; set; } = null!;
}
