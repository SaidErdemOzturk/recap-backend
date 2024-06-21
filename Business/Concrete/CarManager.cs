using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.CarListedById);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CarsListedByBrand);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarsListedByColor);
        }

        public IDataResult<List<CarDto>> GetCarsWithBrandDto()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarsDto(), Messages.CarsDetailListed);
        }

        public IDataResult<List<CarDto>> GetCarsWithBrandDtoByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarsDtoByBrandId(id));
        }

        public IDataResult<List<CarDto>> GetCarsWithBrandDtoByColorId(int id)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetCarsDtoByColorId(id));
        }

        public IDataResult<CarDetailDto> GetCarWithDetailDtoByCarId(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailDtoByCarId(id));
        }
    }
}
