using System;
using System.Collections.Generic;

namespace Warehouse.Data.SQLite;

public partial class ItemWarehouse
{
    public string ItemsId { get; set; } = null!;

    public string WarehousesId { get; set; } = null!;

    public virtual Warehouse Warehouses { get; set; } = null!;
}
