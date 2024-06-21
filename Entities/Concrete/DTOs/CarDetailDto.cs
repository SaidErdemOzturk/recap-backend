using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public int DailyPrice { get; set; }
        public List<CarImage> Images { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
    }
}
