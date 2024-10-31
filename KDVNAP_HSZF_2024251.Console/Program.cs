using KDVNAP_HSZF_2024251.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Intrinsics.X86;

namespace KDVNAP_HSZF_2024251.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Collects the required service for our database
            // AppDbContext setup: use SQl Server Database, read out the configuration from the appsettings.json file
            var serviceProvider = new ServiceCollection() 
                .AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))) 
                .BuildServiceProvider(); 

            using (var context = serviceProvider.GetRequiredService<AppDbContext>())
            {
                context.Database.Migrate(); // Uses the migrations on the database
            }

            var asd = ".asd";
        }
    }
}
