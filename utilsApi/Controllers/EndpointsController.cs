using Microsoft.AspNetCore.Mvc;

namespace utilsApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EndpointsController : ControllerBase
{
    private readonly ILogger<EndpointsController> _logger;

    public EndpointsController(ILogger<EndpointsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPrimeNumbers")]
    public ActionResult<IEnumerable<int>> GetPrimes([FromQuery] int retSize, [FromQuery] int startFrom) 
    { 
        return Ok(EndPoints.primeNumbers(retSize, startFrom)); 
    }

    [HttpGet(Name = "GetFibonacciNumbers")]
    public ActionResult<IEnumerable<int>> GetFibonacci([FromQuery] int retSize, [FromQuery] int startFrom) 
    { 
        return Ok(EndPoints.fibonacci(retSize, startFrom)); 
    }

    [HttpGet(Name = "GetRandChars")]
    public ActionResult<IEnumerable<int>> GetRandChars([FromQuery] int retSize, [FromQuery] int seed) 
    { 
        return Ok(EndPoints.RandomChars(retSize, seed)); 
    }
    
}
