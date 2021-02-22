using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var rentcar = new Rental {CarId=4,CustomerId=2,RentDate=DateTime.Now,ReturnDate=DateTime.Now.AddDays(2) };
            
            Console.WriteLine(rentalManager.Add(rentcar).Message);          

            foreach (var rent in rentalManager.GetAll().Data)
            {              
                Console.WriteLine("Id:{0} CarId={1} CustomerId:{2} RentDate:{3} ReturnDate:{4}",rent.Id,rent.CarId,rent.CustomerId,rent.RentDate,rent.ReturnDate);
            }

            /*foreach (var rentalDetail in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("Id: {0} CarName: {1} BrandName: {2} ColorName: {3} CompanyName: {4} FirstName: {5} LastName: {6} RentDate: {7} ReturnDate: {8} ",
                    rentalDetail.Id, rentalDetail.CarName,rentalDetail.BrandName,rentalDetail.ColorName,rentalDetail.CompanyName,rentalDetail.FirstName,rentalDetail.LastName,
                    rentalDetail.RentDate.ToString("MM/dd/yyyy"), rentalDetail.ReturnDate.ToString("MM/dd/yyyy"));
            }*/

            //DateTime.Now.ToString("MM/dd/yyyy")
        }
    }
}
