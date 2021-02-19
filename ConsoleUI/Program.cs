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
            //InMemoryTest();
            //CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetGetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3} ",car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var color1 = new Color { ColorName = "Test" };

            colorManager.Add(color1);

            color1.ColorName = "Updated";

            colorManager.Update(color1);

            var color2 = new Color { ColorName = "Test2" };

            colorManager.Add(color2);

            colorManager.Delete(color2);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ID: {0} / ColorName: {1}", color.Id, color.ColorName);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var brand1 = new Brand { BrandName = "Test" };

            brandManager.Add(brand1);

            var brand2 = brandManager.Get(2);

            brand2.BrandName = "TestBrand Updated!";

            brandManager.Update(brand2);

            var brand3 = new Brand { BrandName = "Test--" };
            brandManager.Add(brand3);
            brandManager.Delete(brand3);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("ID: {0} / BrandName: {1}", brand.Id, brand.BrandName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car1 = new Car { BrandId = 3, ColorId = 3, ModelYear = 2010, DailyPrice = 94531, Description = "test--" };

            carManager.Add(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }

            Console.WriteLine("----------");

            var updatedCar = carManager.Get(car1.Id);

            updatedCar.Description = "Updated.!!";
            carManager.Update(updatedCar);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }

            Console.WriteLine("-----------------------------");

            carManager.Delete(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColorId + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
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
