using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestApiLearn.Models;
using RestApiLearn.Repositories;
using RestApiLearn.Services;

namespace RestApiLearn.Controllers;

[ApiController]
public class VisitsController : ControllerBase
{
    private readonly IVisitsService _visitsService;

    public VisitsController(IVisitsService visitsService)
    {
        _visitsService = visitsService;
    }


    [HttpGet("/animal/visits")]
    public IActionResult GetVisits()
    {
        var enumerable = _visitsService.GetVisits();
        return Ok(enumerable);
    }

    [HttpGet("/animal/{id:int}/visits")]
    public IActionResult GetVisit(int id)
    {
        var enumerable = _visitsService.GetVisit(id);
        return Ok(enumerable);
    }

    [HttpPost("/animal/visits")]
    public IActionResult CreateVisit(Visit visit)
    {
        int id = 0;
        var enumerable = _visitsService.CreateVisit(id, visit);
        return Ok(enumerable);
    }
}