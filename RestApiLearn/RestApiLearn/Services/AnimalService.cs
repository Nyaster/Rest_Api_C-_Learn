using System.Drawing;
using RestApiLearn.Models;
using RestApiLearn.Repositories;

namespace RestApiLearn.Services;

public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
{
    private readonly IAnimalRepository _animalRepository = animalRepository;

    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        string[] validColumns = { "idanimal", "name", "description", "category", "area" };
        if (!validColumns.Contains(orderBy.ToLower()))
        {
            orderBy = "name";
        }
        var fetchAnimals = _animalRepository.FetchAnimals(orderBy);
        return fetchAnimals;
    }

    public Animal? GetAnimal(int id)
    {
        return _animalRepository.FetchAnimal(id);
    }

    public bool AddAnimal(Animal animal)
    {
        var b = _animalRepository.AddAnimal(animal);
        return b;
    }

    public bool RemoveAnimal(int id)
    {
        return _animalRepository.DeleteAnimal(id);
    }

    public Animal ConvertDtOtoAnimal(int id, AnimalDTO animal)
    {
        Animal createdAnimal = new Animal();
        createdAnimal.Id = id;
        createdAnimal.Name = animal.Name;
        createdAnimal.Category = animal.Category;
        createdAnimal.Description = animal.Description;
        createdAnimal.Area = animal.Area;
        return createdAnimal;
    }

    public Animal ConvertDtOtoAnimal(AnimalDTO animalDto)
    {
        return ConvertDtOtoAnimal(-20, animalDto);
    }

    public bool EditAnimal(Animal animal)
    {
        var updateAnimal = _animalRepository.UpdateAnimal(animal);
        return updateAnimal;
    }
}