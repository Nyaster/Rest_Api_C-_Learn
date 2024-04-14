using RestApiLearn.Models;

namespace RestApiLearn.Repositories;

public class VisitsRepository : IVisitistRepository
{
    private List<Visit> _visits = new List<Visit>()
    {
        new Visit(new DateTime(2000, 12, 1, 12, 45, 00), 1, "Healing paws", 1000),
        new Visit(new DateTime(2000, 12, 1, 12, 45, 00), 2, "Healing paws", 1000),
        new Visit(new DateTime(2000, 11, 1, 12, 45, 00), 2, "Healing", 500)
    };

    public IEnumerable<Visit> GetVisits()
    {
        return _visits;
    }
    
    public bool CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return true;
    }

    public IEnumerable<Visit>? GetVisit(int id)
    {
        return _visits.FindAll(x => x.AnimalId == id);
    }
}