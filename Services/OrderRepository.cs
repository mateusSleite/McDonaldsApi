using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using McDonaldsApi.Services;
using McDonaldsApi.Model;

namespace McDonaldsAPI.Services;

public class OrderRepository : IOrderRepository
{
    private readonly McDataBaseContext ctx;

    public OrderRepository(McDataBaseContext ctx)
        => this.ctx = ctx;

    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore =
            from store in ctx.Stores
            where store.Id == storeId
            select store;
        if (!selectedStore.Any())
            throw new Exception("Store don't exist.");

        var clientOrder = new ClientOrder();

        clientOrder.StoreId = storeId;
        clientOrder.OrderCode = "abcd1234";

        ctx.Add(clientOrder);
        await ctx.SaveChangesAsync();

        return clientOrder.Id;
    }

    public async Task CancelOrder(int orderId)
    {
        var currentOrder = await getOrder(orderId);

        if (currentOrder is null)
            throw new Exception("The order don't exist.");

        ctx.Remove(currentOrder);
        await ctx.SaveChangesAsync();
    }

    public async Task AddItem(int orderId, int productId)
    {
        var order = await getOrder(orderId);

        if (order is null)
            throw new Exception("The order don't exist.");

        var products =
            from product in ctx.MenuItems
            where product.Id == productId
            select product;

        var selectedProduct = await products
            .FirstOrDefaultAsync();

        if (selectedProduct is null)
            throw new Exception("Product don't exist.");

        var item = new ClientOrderItem();
        item.ClientOrderId = orderId;
        item.ProductId = orderId;

        ctx.Add(item);
        await ctx.SaveChangesAsync();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<Product>> GetOrderItems(int orderId)
    {
        var order = await getOrder(orderId);

        if (order is null)
            throw new Exception("The order don't exist.");

        var orderItems = await ctx.ClientOrderItems
                                    .Where(item => item.ClientOrderId == orderId)
                                    .Include(item => item.Product)
                                    .Select(item => item.Product)
                                    .ToListAsync();

        return orderItems;
    }


    public Task DeliveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    private async Task<ClientOrder> getOrder(int orderId)
    {
        var orders =
            from order in ctx.ClientOrders
            where order.Id == orderId
            select order;

        return await orders.FirstOrDefaultAsync();
    }

}