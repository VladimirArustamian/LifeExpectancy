namespace LifeExpectancyAnalyzer.Database
{
    using System.Linq;
    using LifeExpectancyAnalyzer.Models;

    public class DbInitializer
    {
        public static void Initialize(LifeExpectancyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Countries.Any())
            {
                return;
            }

            context.Countries.Add(new Country { CountryName = "Russia", Expectency = 71 });
            
            context.SaveChanges();
        }
    }
}
