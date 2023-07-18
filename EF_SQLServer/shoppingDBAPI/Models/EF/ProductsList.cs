using System;
using System.Collections.Generic;

namespace shoppingDBAPI.Models.EF;

public partial class ProductsList
{
    public int Pid { get; set; }

    public string? PName { get; set; }

    public string? PCategory { get; set; }

    public decimal? PPrice { get; set; }

    public bool? PIsInStock { get; set; }

    public string? PImage { get; set; }
}
