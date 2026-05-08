using Microsoft.AspNetCore.Mvc;
using OrderTakerApi.Contracts;
using OrderTakerServices.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController(IItemsService itemsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemResponseContract>>> GetAllAsync()
    {
        try
        {
            var items = await itemsService.GetAllItemsAsync();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}