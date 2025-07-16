using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OffersController : ControllerBase
{
    private readonly IOffersService _offersService;

    public OffersController(IOffersService offersService)
    {
        _offersService = offersService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<int>> Create([FromBody] OffersRequest request)
    {
        var offerId = await _offersService.CreateOffer(request);
        return Ok(offerId);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string? brand, [FromQuery] string? model, [FromQuery] string? supplier)
    {
        var result = await _offersService.SearchOffers(brand, model, supplier);
        return Ok(result);
    }
}