using RestApiLearn.Models;

namespace RestApiLearn.Services;

public interface IVisitsService
{
    public IEnumerable<Visit> GetVisits();
    public bool CreateVisit(int id, Visit visit);
    public IEnumerable<VisitDto> GetVisit(int id);
}