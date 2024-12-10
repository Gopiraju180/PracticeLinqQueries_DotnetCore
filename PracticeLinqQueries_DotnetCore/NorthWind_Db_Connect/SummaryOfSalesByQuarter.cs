using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_Db_Connect;

public partial class SummaryOfSalesByQuarter
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
