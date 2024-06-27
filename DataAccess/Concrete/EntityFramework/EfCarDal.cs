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
                              where c.CarId == id
                              join color in context.Colors
                              on c.ColorId equals color.ColorId
                              join b in context.Brands
                              on c.BrandId equals b.BrandId
                              select new CarDetailDto
                              {
                                  CarId = c.CarId,
                                  Brand = b,
                                  Color = color,
                                  DailyPrice = c.DailyPrice,
                                  Images = (from images in context.CarImages
                                            where images.CarId == id
                                            select images).ToList(),
                                  Description=c.Description,
                                  ModelYear=c.ModelYear
                              }).FirstOrDefault();
                return result;
            }
        }

        public List<CarDto> GetCarsDto()
        {
            using (var context = new RecapContext())
            {
                var result = from c in context.Cars
                             join color in context.Colors on c.ColorId equals color.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join imageGroup in (
                                 from image in context.CarImages
                                 group image by image.CarId into grouped
                                 select new { CarId = grouped.Key, ImagePath = grouped.FirstOrDefault().ImagePath }
                             ) on c.CarId equals imageGroup.CarId into imageGroups
                             from image in imageGroups.DefaultIfEmpty()
                             select new CarDto()
                             {
                                 CarId = c.CarId,
                                 Brand = b,
                                 Color = color,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = image != null ? image.ImagePath : null,
                                 Description=c.Description
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
                             on c.ColorId equals color.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join imageGroup in (
                                 from image in context.CarImages
                                 group image by image.CarId into grouped
                                 select new { CarId = grouped.Key, ImagePath = grouped.FirstOrDefault().ImagePath }
                             ) on c.CarId equals imageGroup.CarId into imageGroups
                             from image in imageGroups.DefaultIfEmpty()
                             where c.BrandId == id
                             select new CarDto()
                             {
                                 CarId = c.CarId,
                                 Brand = b,
                                 Color = color,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = image.ImagePath,
                                 Description=c.Description
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
                             on c.ColorId equals color.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join imageGroup in (
                                 from image in context.CarImages
                                 group image by image.CarId into grouped
                                 select new { CarId = grouped.Key, ImagePath = grouped.FirstOrDefault().ImagePath }
                             ) on c.CarId equals imageGroup.CarId into imageGroups
                             from image in imageGroups.DefaultIfEmpty()
                             where c.ColorId == id
                             select new CarDto()
                             {
                                 CarId = c.CarId,
                                 Brand = b,
                                 Color = color,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = image.ImagePath,
                                 Description=c.Description

                             };
                return result.ToList();
            }
        }
    }
}
