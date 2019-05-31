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
            new Carbrand() {
                Name="Acura"
            },
            new Carbrand() {
                Name="Alfa romeo"
            },
            new Carbrand() {
                Name="Aston Martin"
            },
            new Carbrand() {
                Name="Audi"
            },
            new Carbrand() {
                Name="Bentley"
            },
            new Carbrand() {
                Name="BMW"
            },
            new Carbrand() {
                Name="Bugatti"
            },
            new Carbrand() {
                Name="Buick"
            },
            new Carbrand() {
                Name="Cadillac"
            },
            new Carbrand() {
                Name="Ferrari"
            },
            new Carbrand() {
                Name="Ford"
            },
            new Carbrand() {
                Name="George Patton"
            },
            new Carbrand() {
                Name="Honda"
            },
            new Carbrand() {
                Name="Hummer"
            },
            new Carbrand() {
                Name="Jaguar"
            },
            new Carbrand() {
                Name="Jeep"
            },
            new Carbrand() {
                Name="Lamborghini"
            },
            new Carbrand() {
                Name="Land rover"
            },
            new Carbrand() {
                Name="Maserati"
            },
            new Carbrand() {
                Name="McLaren"
            },
            new Carbrand() {
                Name="Nissan"
            },
            new Carbrand() {
                Name="Pagani"
            },
            new Carbrand() {
                Name="Porsche"
            },
            new Carbrand() {
                Name="Rolls-Royce"
            },
            new Carbrand() {
                Name="Toyota"
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
                Price= 227.88m,
                PictureUrl="images/Benz.jpg"

    },
            new Car() {
                Model="Maybach",
                Type="limousine",
                Grade="S",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 138.08m,
                 PictureUrl="images/Benz.jpg"
            },
            new Car() {
                Model="AMG G63",
                Type="SUV",
                Grade="G",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 215.88m,
                 PictureUrl="images/Benz.jpg"
            },
            new Car() {
                Model="AMG GLS63 4MATIC+",
                Type="SUV",
                Grade="G",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 179.98m,
                 PictureUrl="images/Benz.jpg"
            },
            new Car() {
                Model="V-class utility vehicle",
                Type="MPV",
                Grade="V",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 47.18m,
                 PictureUrl="images/Benz.jpg"
            },
            new Car() {
                Model="AMG C63",
                Type="COUPE",
                Grade="C",
                Name=context.Carbrands.Find("Mercedes-Benz").Name,
                Price= 95.28m,
                 PictureUrl="images/Benz.jpg"
            },
            new Car() {
                Model="F12berlinetta",
                Type="Supercar",
                Grade="S",
                Name=context.Carbrands.Find("Ferrari").Name,
                Price=530.8m,
                 PictureUrl="images/F.jpg"
            },
            new Car() {
                Model="Aventador",
                Type="Supercar",
                Grade="S",
                Name=context.Carbrands.Find("Lamborghini").Name,
                Price= 613.70m,
                 PictureUrl="images/L.jpg"
            },
            new Car() {
                Model="918",
                Type="Supercar",
                Grade="S",
                Name=context.Carbrands.Find("Porsche").Name,
                Price= 1338.8m,
                 PictureUrl="images/P.jpg"
            },
            new Car() {
                Model="Continental",
                Type="Supercar",
                Grade="S",
                Name=context.Carbrands.Find("Bentley").Name,
                Price= 288.00m,
                 PictureUrl="images/B.jpg"
            },

        };

            return Cars;
        }
    }

}
