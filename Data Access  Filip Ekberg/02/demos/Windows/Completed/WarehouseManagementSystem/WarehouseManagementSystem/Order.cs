using System;
using System.Collections.Generic;

namespace WarehouseManagementSystem;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid ShippingProviderId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<LineItem> LineItems { get; set; } = new List<LineItem>();

    public virtual ShippingProvider ShippingProvider { get; set; } = null!;
}
