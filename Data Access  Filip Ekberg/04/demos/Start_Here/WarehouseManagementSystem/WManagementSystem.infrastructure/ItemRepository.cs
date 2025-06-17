using WarehouseManagementSystem;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Web;

namespace WManagementSystem.infrastructure;

public class ItemRepository : GenericRepository<Item>
{
    public ItemRepository(WarehouseContext context) 
        : base(context)
    {
    }

    public override Item Update(Item entity)
    {
        Item toUpdate = GetValue(entity.Id);
        toUpdate.Price = entity.Price;
        toUpdate.Name = entity.Name;

        return base.Update(entity);
    }
}


    