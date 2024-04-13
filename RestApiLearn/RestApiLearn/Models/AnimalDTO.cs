using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace RestApiLearn.Models;

public class AnimalDTO
{
    public int Id { get; set; }
    [Required] public AnimalType AnimalType { get; set; }
    [Required] public string Name { get; set; }
    [Required] public double Weight { get; set; }
    [Required] public String Color { get; set; }
}