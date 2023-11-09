using System.Collections.Generic;
using System.Threading.Tasks;
using McDonaldsApi.Model;

namespace McDonaldsApi.Services;

public interface IOrderRepository 
{
    Task<int> CreateOrder(int Store);
    Task CancelOrder(int orderId);
    Task<List<Product>> GetMenu(int orderId);
    Task<List<Product>> GetOrderItems(int orderId);
    Task AddItem(int orderId, int itemId);
    Task RemoveItem(int orderId, int itemId);
    Task FinishOrder(int orderId);
    Task DeliveryOrder(int orderId);
}