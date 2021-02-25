using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new CarRentalContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars on rent.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join cus in context.Customers on rent.CustomerId equals cus.Id
                             join user in context.Users on cus.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 Id = rent.Id,
                                 CarName = car.Description,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CompanyName = cus.CompanyName,
                                 FirstName=user.FirstName,
                                 LastName=user.LastName,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate,
                             };

                return result.ToList();
            }
        }
    }
}
