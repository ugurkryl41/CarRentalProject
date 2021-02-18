using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());        

            carManager.Update(new Car { Id = 0, BrandId = 2, ColorId = 33, ModelYear = 2014, DailyPrice = 56929, Descripton = "Info.1" });
            carManager.Update(new Car { Id = 1, BrandId = 2, ColorId = 15, ModelYear = 2020, DailyPrice = 96723, Descripton = "Info.2" });

            carManager.Delete(new Car { Id = 2 });

            carManager.Add(new Car { Id = 2, BrandId = 9, ColorId = 12, ModelYear = 1998, DailyPrice = 21312, Descripton = "Info.3" });

            var result = carManager.GetById(2);
            Console.WriteLine(result.Id + " " + result.BrandId + " " + result.ColorId + " " + result.ModelYear + " " + result.DailyPrice + " " + result.Descripton);

            Console.WriteLine("---All Car---");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Descripton);
            }
        }
    }
}
