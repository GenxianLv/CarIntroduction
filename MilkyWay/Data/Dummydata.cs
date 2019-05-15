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
                        new Car() {
                Model="Maybach",
                Type="limousine",
                Grade="S",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 138.08m
            },
            new Car() {
                Model="AMG G63",
                Type="SUV",
                Grade="G",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 215.88m
            },
            new Car() {
                Model="AMG GLS63 4MATIC+",
                Type="SUV",
                Grade="G",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 179.98m
            },
            new Car() {
                Model="V-class utility vehicle",
                Type="MPV",
                Grade="V",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 47.18m
            },
            new Car() {
                Model="AMG C63",
                Type="COUPE",
                Grade="C",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 95.28m
            },


        };

            return Cars;
        }
    }
}
