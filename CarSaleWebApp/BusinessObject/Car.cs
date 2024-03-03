using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Car
{
    public string Carid { get; set; } = null!;

    public string Carname { get; set; } = null!;

    public string ManufacturerId { get; set; } = null!;

    public DateOnly PublishDate { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Manufacturer Manufacturer { get; set; } = null!;
}
