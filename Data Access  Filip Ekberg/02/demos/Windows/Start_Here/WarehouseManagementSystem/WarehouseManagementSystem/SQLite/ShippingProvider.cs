using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite;

public partial class ShippingProvider
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal FreightCost { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
