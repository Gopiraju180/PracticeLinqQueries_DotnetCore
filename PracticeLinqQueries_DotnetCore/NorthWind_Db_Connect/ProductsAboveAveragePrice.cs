using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_Db_Connect;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
