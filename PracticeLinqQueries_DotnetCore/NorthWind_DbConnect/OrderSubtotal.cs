using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_DbConnect;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
