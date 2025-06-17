using Microsoft.EntityFrameworkCore;
using Warehouse.Data.SQLite;
using WarehouseManagementSystem;
using LineItem = Warehouse.Data.SQLite.LineItem;
using Customer = Warehouse.Data.SQLite.Customer;
using Order = Warehouse.Data.SQLite.Order;

using WarehouseManagementSystem.Models;


using var context = new WarehouseSQLiteContext();

var firstCustomer = context.Customers.First();

Order newOrder = new()
{
    Id = Guid.NewGuid(),
    LineItems = new LineItem[]
    {
        new()
        {
            Id = Guid.NewGuid(),
            Item = context.Items.First(),
            Quantity = 1
        }
    },
    ShippingProvider = context.ShippingProviders.First(),
    Customer = firstCustomer
};

context.Orders.Add(newOrder);
context.SaveChanges();
Console.WriteLine("Order Added!");
