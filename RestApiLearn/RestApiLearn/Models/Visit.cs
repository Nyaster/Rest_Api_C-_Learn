namespace RestApiLearn.Models;

public class Visit
{
    public DateTime VisitDate { get; set; }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public int Price;

    public Visit(DateTime dateTime, int animalId, string description, int price)
    {
        VisitDate = dateTime;
        AnimalId = animalId;
        Description = description;
        Price = price;
    }
}