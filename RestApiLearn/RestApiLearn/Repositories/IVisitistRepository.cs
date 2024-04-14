using RestApiLearn.Models;

namespace RestApiLearn.Repositories;

public interface IVisitistRepository
{
    public IEnumerable<Visit> GetVisits();
    public bool CreateVisit(Visit visit);
    public IEnumerable<Visit> GetVisit(int id);
}