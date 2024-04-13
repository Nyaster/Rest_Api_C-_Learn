using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Cryptography;

namespace RestApiLearn.Models;

public class Animal : IEquatable<Animal>
{
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Animal)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public Animal(int id, AnimalType animalType, string name, double weight, Color color)
    {
        Id = id;
        AnimalType = animalType;
        Name = name;
        Weight = weight;
        Color = color;
    }

    public Animal()
    {
    }

    public int Id { get; set; }

    [Required]
    [EnumDataType(typeof(AnimalType))]
    public AnimalType AnimalType { get; set; }

    [Required] public string Name { get; set; }
    [Required] public double Weight { get; set; }
    [Required] public Color Color { get; set; }

    public bool Equals(Animal? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }
}