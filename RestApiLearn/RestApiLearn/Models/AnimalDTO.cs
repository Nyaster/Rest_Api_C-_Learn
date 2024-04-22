using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace RestApiLearn.Models;

public class AnimalDTO
{
    public AnimalDTO(string category, string name, string description, string area)
    {
        Category = category;
        Name = name;
        Description = description;
        Area = area;
    }

    [Required] public String Category { get; }
    [Required] public string Name { get; }
    [Required] public string Description { get; }
    [Required] public String Area { get; }
}