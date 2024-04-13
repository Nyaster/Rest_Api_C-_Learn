using System.Drawing;
using RestApiLearn.Models;
using RestApiLearn.Repositories;

namespace RestApiLearn.Services;

public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
{
    private readonly IAnimalRepository _animalRepository = animalRepository;

    public IEnumerable<Animal> GetAnimals()
    {
        return _animalRepository.FetchAnimals();
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

    public Animal ConvertDtOtoAnimal(AnimalDTO animal)
    {
        var createdAnimalColor = Color.FromName(animal.Color);
        Animal createdAnimal = new Animal();
        if (!createdAnimalColor.IsKnownColor)
        {
            return null;
        }

        createdAnimal.Id = animal.Id;
        createdAnimal.Name = animal.Name;
        createdAnimal.Weight = animal.Weight;
        createdAnimal.Color = createdAnimalColor;
        return createdAnimal;
    }

    public bool EditAnimal(Animal animal)
    {
        var updateAnimal = _animalRepository.UpdateAnimal(animal);
        return updateAnimal;
    }
}