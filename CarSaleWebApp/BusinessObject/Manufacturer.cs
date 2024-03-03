using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Manufacturer
{
    public string ManufacturerId { get; set; } = null!;

    public string ManufacturerName { get; set; } = null!;

    public decimal ManufacturerSaleCount { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
