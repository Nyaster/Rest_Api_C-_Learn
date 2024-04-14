namespace RestApiLearn.Models;

public class VisitDto
{
    public DateTime VisitDate { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public int Price;

    public VisitDto(DateTime dateTime, Animal animal, string description, int price)
    {
        VisitDate = dateTime;
        Animal = animal;
        Description = description;
        Price = price;
    }
}