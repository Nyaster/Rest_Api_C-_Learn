using Microsoft.AspNetCore.Mvc;
using RestApiLearn.Models;

namespace RestApiLearn.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAnimals();
    Animal? GetAnimal(int id);
    bool AddAnimal(Animal animal);
    bool RemoveAnimal(int id);
    Animal? ConvertDtOtoAnimal(AnimalDTO animalDto);
    bool EditAnimal(Animal animal);
}