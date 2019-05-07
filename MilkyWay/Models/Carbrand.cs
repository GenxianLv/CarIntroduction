using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilkyWay.Models
{
    public class Carbrand
    {
        [Key]
        public string Name { get; set; }
        public int BrandId { get; set; }

        public List<Car> Cars { get; set; }
    }
}
