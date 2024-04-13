using RestApiLearn.Models;

namespace RestApiLearn.Repositories;

public interface IAnimalRepository
{
    Animal FetchAnimal(int id);
    IEnumerable<Animal> FetchAnimals();
    bool DeleteAnimal(int id);
    bool UpdateAnimal(Animal animal);
    bool AddAnimal(Animal animal);
}