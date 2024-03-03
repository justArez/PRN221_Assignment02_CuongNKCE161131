using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Invoice
{
    public string Invoiceid { get; set; } = null!;

    public string Userid { get; set; } = null!;

    public string Carid { get; set; } = null!;

    public DateOnly InvoiceDate { get; set; }

    public decimal? TotalCharge { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
