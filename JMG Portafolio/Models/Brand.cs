using System;
using System.Collections.Generic;

namespace JMG_Portafolio.Models;

public partial class Brand
{
    public int Brandid { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
}
