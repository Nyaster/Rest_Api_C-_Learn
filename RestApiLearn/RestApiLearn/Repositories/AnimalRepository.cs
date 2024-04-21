using System.Data.SqlClient;
using System.Drawing;
using RestApiLearn.Models;

namespace RestApiLearn.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private List<Animal> _animals = new List<Animal>()
    {
        new Animal(1, AnimalType.CAT, "Morpy", 24, Color.Gray),
        new Animal(2, AnimalType.DOG, "Rex", 30, Color.Black),
        new Animal(3, AnimalType.FOX, "Holo", 7, Color.SaddleBrown),
        new Animal(4, AnimalType.WOLF, "Faust", 22, Color.Gray),
        new Animal(5, AnimalType.CAT, "Nyan", 11, Color.Blue),
    };

    public Animal? FetchAnimal(int id)
    {
        SqlConnection sqlConnection = new SqlConnection("Server=db-mssql;Database=Server=db-mssql ;Database=2019SBD;Trusted_Connection=True;Trusted_Connection=True;");
        SqlCommand sqlCommand = new SqlCommand();
        sqlConnection.Open();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = "Select id from Film";
        var sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            Console.WriteLine(sqlDataReader["id"]);
        }

        return _animals.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Animal> FetchAnimals()
    {
        return _animals;
    }

    public bool DeleteAnimal(int id)
    {
        var animal = _animals.Find(x => x.Id == id);
        return animal != null;
    }

    public bool UpdateAnimal(Animal animal)
    {
        var contains = _animals.Contains(animal);
        if (contains)
        {
            _animals.Remove(animal);
            _animals.Add(animal);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddAnimal(Animal animal)
    {
        if (_animals.Contains(animal))
        {
            return false;
        }

        _animals.Add(animal);
        return true;
    }
}