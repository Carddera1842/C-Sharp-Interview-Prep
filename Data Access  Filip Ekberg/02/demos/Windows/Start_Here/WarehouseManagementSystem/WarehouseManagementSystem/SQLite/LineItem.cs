using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite;

public partial class LineItem
{
    public Guid Id { get; set; }

    public Guid ItemId { get; set; }

    public int Quantity { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual ShippingProvider? ShippingProvider { get; set; }
}
