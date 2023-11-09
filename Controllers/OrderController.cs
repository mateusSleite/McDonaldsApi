using System;
using System.Threading.Tasks;
using McDonaldsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace McDonaldsAPI.Controllers;


[ApiController]
[Route("order")]
public class OrderController : ControllerBase
{
    [HttpPost("create/{storeId}")]
    public async Task<ActionResult> CreateOrder(int storeId, [FromServices] IOrderRepository repo)
    {
        try
        {
            var orderId = await repo.CreateOrder(storeId);
            return Ok(orderId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("cancel/{storeId}")]
    public async Task<ActionResult> CancelOrder(int storeId, [FromServices] IOrderRepository repo)
    {
        try
        {
            await repo.CancelOrder(storeId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost("additem/{orderId}/{productId}")]
    public async Task<ActionResult> AddItem(int orderId,  int productId, [FromServices] IOrderRepository repo)
    {
        try
        {
            await repo.AddItem(orderId, productId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}