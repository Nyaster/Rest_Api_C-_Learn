namespace RestApiLearn;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("secrets.json", optional: true, reloadOnChange: true).Build();
        builder.Configuration.AddConfiguration(configuration);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers().AddXmlSerializerFormatters();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine(connectionString);
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}