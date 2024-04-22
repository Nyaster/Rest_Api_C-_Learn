using System.Data.SqlClient;
using System.Drawing;
using RestApiLearn.Models;

namespace RestApiLearn.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Animal? FetchAnimal(int id)
    {
        Animal animal = new Animal();
        using (SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                "Select IdAnimal, Name,Description,Category,Area from Animal where IdAnimal=@IdAnimal";
            sqlCommand.Parameters.AddWithValue("@IdAnimal", id);
            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                animal.Id = (int)sqlDataReader["IdAnimal"];
                animal.Name = sqlDataReader["Name"].ToString();
                animal.Description = sqlDataReader["Description"].ToString();
                animal.Category = sqlDataReader["Category"].ToString();
                animal.Area = sqlDataReader["Area"].ToString();
            }
        }

        return animal;
    }

    public IEnumerable<Animal> FetchAnimals(String orderBy)
    {
        List<Animal> animals = new List<Animal>();
        using (SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "Select IdAnimal, Name,Description,Category,Area from Animal order by "+orderBy;
            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Animal animal = new Animal();
                animal.Id = (int)sqlDataReader["IdAnimal"];
                animal.Name = sqlDataReader["Name"].ToString();
                animal.Description = sqlDataReader["Description"].ToString();
                animal.Category = sqlDataReader["Category"].ToString();
                animal.Area = sqlDataReader["Area"].ToString();
                animals.Add(animal);
            }
        }

        return animals;
    }

    public bool DeleteAnimal(int id)
    {
        var executeNonQuery = 0;
        using (SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = " delete from Animal where IdAnimal=@IdAnimal";
            sqlCommand.Parameters.AddWithValue("@IdAnimal", id);

            executeNonQuery = sqlCommand.ExecuteNonQuery();
        }

        return executeNonQuery > 0;
    }

    public bool UpdateAnimal(Animal animal)
    {
        var executeNonQuery = 0;
        using (SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                " update from Animal set Name=@Name,Description=@Description,Area=@Area,Category=@Category where IdAnimal=@IdAnimal";
            sqlCommand.Parameters.AddWithValue("@Name", animal.Name);
            sqlCommand.Parameters.AddWithValue("@Description", animal.Description);
            sqlCommand.Parameters.AddWithValue("@Area", animal.Area);
            sqlCommand.Parameters.AddWithValue("@Category", animal.Category);
            executeNonQuery = sqlCommand.ExecuteNonQuery();
        }

        return executeNonQuery > 0;
    }

    public bool AddAnimal(Animal animal)
    {
        var executeNonQuery = 0;
        using (SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                " insert into Animal(Name,Description,Category,Area)  values (@Name,@Description,@Category,@Area)";
            sqlCommand.Parameters.AddWithValue("@Name", animal.Name);
            sqlCommand.Parameters.AddWithValue("@Description", animal.Description);
            sqlCommand.Parameters.AddWithValue("@Area", animal.Area);
            sqlCommand.Parameters.AddWithValue("@Category", animal.Category);
            executeNonQuery = sqlCommand.ExecuteNonQuery();
        }

        return executeNonQuery > 0;
    }
}