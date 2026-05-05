using Microsoft.AspNetCore.Mvc;
using OrderTakerApi.Contracts;
using OrderTakerServices.Interfaces;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController(IItemsService itemsService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ItemResponseContract>> GetAll()
    {
        try
        {
            var items = itemsService.GetAllItems();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}