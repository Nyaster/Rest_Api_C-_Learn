using RestApiLearn.Models;
using RestApiLearn.Repositories;

namespace RestApiLearn.Services;

public class VisitsService : IVisitsService
{
    private readonly IVisitistRepository _visitistRepository;
    private readonly IAnimalService _animalService;

    public VisitsService(IVisitistRepository visitistRepository, IAnimalService animalService)
    {
        _visitistRepository = visitistRepository;
        _animalService = animalService;
    }

    public bool CreateVisit(int id, Visit visit)
    {
        return _visitistRepository.CreateVisit(visit);
    }

    public IEnumerable<VisitDto> GetVisit(int id)
    {
        var enumerable = _visitistRepository.GetVisit(id);
        List<VisitDto> returnedList = new List<VisitDto>();
        foreach (var visit in enumerable)
        {
            var animal = _animalService.GetAnimal(visit.AnimalId);
            if (animal == null)
            {
                returnedList = null;
                break;
            }
            returnedList.Add(new VisitDto(visit.VisitDate, animal, visit.Description,
                visit.Price));
        }


        return returnedList;
    }

    public IEnumerable<Visit> GetVisits()
    {
        List<VisitDto> visitDtos = new List<VisitDto>();
        var enumerable = _visitistRepository.GetVisits();
        foreach (var visit in enumerable)
        {
            visitDtos.Add(new VisitDto(visit.VisitDate,_animalService.GetAnimal(visit.AnimalId),visit.Description,visit.Price));
        }
        return enumerable;
    }
}