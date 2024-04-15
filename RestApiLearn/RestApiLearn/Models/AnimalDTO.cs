using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace RestApiLearn.Models;

public class AnimalDTO
{
    public AnimalDTO(AnimalType animalType, string name, double weight, string color)
    {
        AnimalType = animalType;
        Name = name;
        Weight = weight;
        Color = color;
    }
    
    [Required] public AnimalType AnimalType { get; }
    [Required] public string Name { get; }
    [Required] public double Weight { get; }
    [Required] public String Color { get; }
}