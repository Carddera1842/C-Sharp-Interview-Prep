using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite;

public partial class Warehouse
{
    public string Id { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<ItemWarehouse> ItemWarehouses { get; set; } = new List<ItemWarehouse>();
}
