using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDto> GetCarsDto();
        List<CarDto> GetCarsDtoByBrandId(int id);
        List<CarDto> GetCarsDtoByColorId(int id);
        CarDetailDto GetCarDetailDtoByCarId(int id);
    }
}
