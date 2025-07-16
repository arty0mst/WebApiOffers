using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SuppliersController : ControllerBase
{
    private readonly ISuppliersService _suppliersService;

    public SuppliersController(ISuppliersService suppliersService)
    {
        _suppliersService = suppliersService;
    }

    [HttpGet]
    [Route("top")]
    public async Task<ActionResult<List<SuppliersTopResponse>>> GetTop()
    {
        var suppliersTop = await _suppliersService.GetTop();

        return Ok(suppliersTop);
    }
}