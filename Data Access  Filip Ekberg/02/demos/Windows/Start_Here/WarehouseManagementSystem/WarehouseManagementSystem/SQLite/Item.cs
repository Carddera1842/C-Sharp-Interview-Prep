using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite;

public partial class Item
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int InStock { get; set; }

    public virtual ICollection<LineItem> LineItems { get; set; }

    public virtual ICollection<Warehouse> WarehouseItems { get; set; }
}
