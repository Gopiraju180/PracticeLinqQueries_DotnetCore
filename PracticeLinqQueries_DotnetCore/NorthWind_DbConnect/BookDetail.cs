﻿using System;
using System.Collections.Generic;

namespace PracticeLinqQueries_DotnetCore.NorthWind_DbConnect;

public partial class BookDetail
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public string? Author { get; set; }

    public string? Publisher { get; set; }

    public decimal Price { get; set; }
}
