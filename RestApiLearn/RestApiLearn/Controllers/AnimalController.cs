using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RestApiLearn.Models;
using RestApiLearn.Services;

namespace RestApiLearn.Controllers;

[Route("/animal")]
[ApiController]
public class AnimalController(IAnimalService animalService) : ControllerBase
{
    private readonly IAnimalService _animalService = animalService;

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalService.GetAnimals();
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        Animal? animal = _animalService.GetAnimal(id);
        if (animal == null)
        {
            return NotFound($"Animal with id:{id} was not found");
        }

        return Ok(animal);
    }

    [HttpPut("{id:int}")]
    public IActionResult EditAnimal(int id, AnimalDTO animalDto)
    {
        var createdAnimal = _animalService.ConvertDtOtoAnimal(animalDto);
        createdAnimal.Id = id;
        var editAnimal = _animalService.EditAnimal(createdAnimal);
        return editAnimal ? Ok("Animal edidet succefuly") : NotFound("Animal with this id not found");
    }

    [HttpPost]
    public IActionResult AddAnimal(AnimalDTO animal)
    {
        var createdAnimal = _animalService.ConvertDtOtoAnimal(animal);
        var addAnimal = _animalService.AddAnimal(createdAnimal);
        return addAnimal ? Ok("Animal is added") : Conflict("Same animal is already exist");
    }

    [HttpDelete("{id:int}")]
    public IActionResult RemoveAnimal(int id)
    {
        return _animalService.RemoveAnimal(id)
            ? Ok("Animal delete succefuly")
            : NotFound("Animal with this id not found");
    }
}