﻿using Microsoft.AspNetCore.Mvc;
using RestApiLearn.Models;

namespace RestApiLearn.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAnimals(String orderBy);
    Animal? GetAnimal(int id);
    bool AddAnimal(Animal animal);
    bool RemoveAnimal(int id);
    Animal ConvertDtOtoAnimal(int id,AnimalDTO animalDto);
    Animal ConvertDtOtoAnimal(AnimalDTO animalDto);
    bool EditAnimal(Animal animal);
}