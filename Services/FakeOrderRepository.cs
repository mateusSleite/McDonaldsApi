using System.Collections.Generic;
using System.Threading.Tasks;
using McDonaldsApi.Model;
using McDonaldsApi.Services;

public class FakeOrderRepository : IOrderRepository
{

    int orderId = 42;

    public Task AddItem(int orderId, int itemId)
    {
        throw new System.NotImplementedException();
    }

    public Task CancelOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateOrder(int Store)
    {
        return orderId;
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveItem(int orderId, int itemId)
    {
        throw new System.NotImplementedException();
    }
}