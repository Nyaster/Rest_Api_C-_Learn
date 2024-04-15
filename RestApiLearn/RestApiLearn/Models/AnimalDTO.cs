using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace RestApiLearn.Models;

public class AnimalDTO
{
    public AnimalDTO(int id, AnimalType animalType, string name, double weight, string color)
    {
        Id = id;
        AnimalType = animalType;
        Name = name;
        Weight = weight;
        Color = color;
    }

    public int Id { get; }
    [Required] public AnimalType AnimalType { get; }
    [Required] public string Name { get; }
    [Required] public double Weight { get; }
    [Required] public String Color { get; }
}