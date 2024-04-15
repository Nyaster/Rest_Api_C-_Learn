namespace RestApiLearn.Models;

public class VisitDto
{
    public DateTime VisitDate { get; }
    public Animal Animal { get; }
    public string Description { get; }
    public int Price;

    public VisitDto(DateTime dateTime, Animal animal, string description, int price)
    {
        VisitDate = dateTime;
        Animal = animal;
        Description = description;
        Price = price;
    }
}