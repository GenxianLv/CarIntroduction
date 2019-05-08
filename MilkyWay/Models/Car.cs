using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkyWay.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Grade { get; set; }
        public decimal Price { get; set; }

        public string Name { get; set;}
        public Carbrand Carbrand { get; set; }
    }
}
