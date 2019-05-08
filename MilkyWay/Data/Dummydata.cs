using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MilkyWay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkyWay.Data
{
    public class Dummydata
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any Provinces.
                if (context.Carbrands.Any())
                {
                    return;   // DB has already been seeded
                }

                var Carbrands = Dummydata.GetCarbrands().ToArray();
                context.Carbrands.AddRange(Carbrands);
                context.SaveChanges();


                var Cars = Dummydata.GetCars(context).ToArray();
                context.Cars.AddRange(Cars);
                context.SaveChanges();
            }
        }
        public static List<Carbrand> GetCarbrands()
        {
            List<Carbrand> Carbrands = new List<Carbrand>() {
            new Carbrand() {
                Name="Mercedes-Benz"
            },
        };

            return Carbrands;
        }

        public static List<Car> GetCars(ApplicationDbContext context)
        {
            List<Car> Cars = new List<Car>() {
            new Car() {
                Model="AMG S63L 4MATIC+",
                Type="limousine",
                Grade="S",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 227.88m


            },

        };

            return Cars;
        }
    }
}
