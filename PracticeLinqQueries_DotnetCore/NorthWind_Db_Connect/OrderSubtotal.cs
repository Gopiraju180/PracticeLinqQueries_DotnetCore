using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_Db_Connect;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
