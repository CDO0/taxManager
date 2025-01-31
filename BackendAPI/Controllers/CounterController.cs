using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/counter")]
public class CounterController : ControllerBase
{
    private static int _count = 0; 

    [HttpPost]
    public IActionResult UpdateCount([FromBody] CounterRequest request)
    {
        if (request == null || request.Count < 0)
        {
            return BadRequest("Invalid count value.");
        }

        _count = request.Count;  
        return Ok(new { message = $"Count received: {_count}", count = _count });
    }

    [HttpGet]
    public IActionResult GetCount()
    {
        return Ok(new { count = _count });
    }
}

// DTO (Data Transfer Object) for receiving data
public class CounterRequest
{
    public int Count { get; set; }
}
