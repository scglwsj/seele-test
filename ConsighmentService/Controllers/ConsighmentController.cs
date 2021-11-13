using Microsoft.AspNetCore.Mvc;
using ConsighmentService.Services;
using ConsighmentService.Services.Models;

namespace ConsighmentService.Controllers;

[ApiController]
[Route("consignments")]
public class ConsighmentController : ControllerBase
{
    private readonly ConsighmentBussinessService ConsighmentService;

    public ConsighmentController(ConsighmentBussinessService ConsighmentService)
    {
        this.ConsighmentService = ConsighmentService;
    }

    [HttpGet("{id}")]
    public Consighment GetConsighment(string id)
    {
        return ConsighmentService.GetConsighment(id);
    }

    [HttpPost("{id}/commission")]
    public IActionResult CommissionRequest(string id)
    {
        ConsighmentService.CreateCommissionRequest(id);
        return Created("consignments", null);
    }
}
