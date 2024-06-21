using Business.Abstract;
using Business.Constans;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        //[PerformanceAspect(5)]
        //[TransactionScopeAspect]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckRentedCarIsDelivered(rental.CarId));
            if(result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAddedSuccessful);
            }
            else
            {
                return result;
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(_rentalDal.Get(b => b.Id == rental.Id));
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id==id));
        }

        public IDataResult<List<Rental>> GetRentalsByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult <List<RentalDetailDto>> GetRentalWithDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDtos());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
        private IResult CheckRentedCarIsDelivered(int carId)
        {
                var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).SingleOrDefault();
                if (result == null)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();
        }
    }
}
