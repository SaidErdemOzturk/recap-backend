using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDto>> GetCarsWithBrandDto();
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDto>> GetCarsWithBrandDtoByBrandId(int id);
        IDataResult<List<CarDto>> GetCarsWithBrandDtoByColorId(int id);
        IDataResult<CarDetailDto> GetCarWithDetailDtoByCarId(int id);
    }
}
