using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public CarDetailDto GetCarDetailDtoByCarId(int id)
        {
            using (var context = new RecapContext())
            {
                var result = (from c in context.Cars
                              where c.Id == id
                              join color in context.Colors
                              on c.ColorId equals color.Id
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              select new CarDetailDto
                              {
                                  CarId = c.Id,
                                  BrandName = b.BrandName,
                                  ColorName = color.ColorName,
                                  DailyPrice = c.DailyPrice,
                                  Images = (from images in context.CarImages
                                            where images.CarId == id
                                            select images).ToList()
                              }).FirstOrDefault();
                return result;
            }
        }

        public List<CarDto> GetCarsDto()
        {
            using (var context = new RecapContext())
            {
                var result = from c in context.Cars
                             join color in context.Colors on c.ColorId equals color.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join imageGroup in (
                                 from image in context.CarImages
                                 group image by image.CarId into grouped
                                 select new { CarId = grouped.Key, ImagePath = grouped.FirstOrDefault().ImagePath }
                             ) on c.Id equals imageGroup.CarId into imageGroups
                             from image in imageGroups.DefaultIfEmpty()
                             select new CarDto()
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = image != null ? image.ImagePath : null
                             };
                return result.ToList();
            }
        }

        public List<CarDto> GetCarsDtoByBrandId(int id)
        {
            using (var context = new RecapContext())
            {
                var result = from c in context.Cars
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join image in context.CarImages
                             on c.Id equals image.CarId
                             where c.BrandId == id
                             select new CarDto()
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = image.ImagePath,
                             };
                return result.ToList();
            }
        }

        public List<CarDto> GetCarsDtoByColorId(int id)
        {
            using (var context = new RecapContext())
            {
                var result = from c in context.Cars
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join image in context.CarImages
                             on c.Id equals image.CarId
                             where c.ColorId == id
                             select new CarDto()
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = image.ImagePath,

                             };
                return result.ToList();
            }
        }
    }
}
