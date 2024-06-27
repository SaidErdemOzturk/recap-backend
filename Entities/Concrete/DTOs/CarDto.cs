using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class CarDto
    {
        public int CarId { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public int DailyPrice { get; set; }
        public string ImagePath { get; set; }
        public string Description  { get; set; }
    }
}
