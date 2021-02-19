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
            CarManager carManager = new CarManager(new EfCarDal());

            var var1 = new Car { BrandId = 1, ColorId = 1, ModelYear = 2012, DailyPrice = 0, Description = "acc" };           

            carManager.Add(var1);

            /*var result = carManager.GetAll();

            foreach (var car in result)
            {
                Console.WriteLine("Id:{0}, BrandId:{1}, ColorId:{2}, ModelYear:{3}, DailyPrice:{4}$, Descripton:{5}",car.Id,car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description);
            }*/

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            //carManager.Update(new Car { Id = 0, BrandId = 2, ColorId = 33, ModelYear = 2014, DailyPrice = 56929, Description = "Info.1" });
            //carManager.Update(new Car { Id = 1, BrandId = 2, ColorId = 15, ModelYear = 2020, DailyPrice = 96723, Description = "Info.2" });
            //carManager.Delete(new Car { Id = 2 });

            carManager.Add(new Car { Id = 2, BrandId = 9, ColorId = 12, ModelYear = 1998, DailyPrice = 21312, Description = "Info.3" });

            //var result = carManager.GetById(2);
            //Console.WriteLine(result.Id + " " + result.BrandId + " " + result.ColorId + " " + result.ModelYear + " " + result.DailyPrice + " " + result.Description);

            Console.WriteLine("---All Car---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }
        }
    }
}
