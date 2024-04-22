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

    public Animal(int id, string name, string category, string area, string description)
    {
        Id = id;
        Name = name;
        Category = category;
        Area = area;
        Description = description;
    }

    public Animal()
    {
    }

    public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Category { get; set; }
    [Required] public string Area { get; set; }
    public string Description { get; set; }

    public bool Equals(Animal? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }
}