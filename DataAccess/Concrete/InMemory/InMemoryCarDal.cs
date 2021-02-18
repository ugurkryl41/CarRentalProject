using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=0,BrandId=2,ColorId=33,ModelYear=2014,DailyPrice=56929,Descripton="Info." },
                new Car{Id=1,BrandId=2,ColorId=15,ModelYear=2020,DailyPrice=96723,Descripton="Info." },
                new Car{Id=2,BrandId=2,ColorId=78,ModelYear=1994,DailyPrice=26173,Descripton="Info." },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedToCar = null;

            deletedToCar=_cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(deletedToCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(p => p.Id == Id);
        }

        public void Update(Car car)
        {
            Car updatedToCar = null;

            updatedToCar = _cars.SingleOrDefault(p => p.Id == car.Id);

            updatedToCar.Id = car.Id;
            updatedToCar.BrandId = car.BrandId;
            updatedToCar.ColorId = car.ColorId;
            updatedToCar.ModelYear = car.ModelYear;
            updatedToCar.DailyPrice = car.DailyPrice;
            updatedToCar.Descripton = car.Descripton;
        }
    }
}
