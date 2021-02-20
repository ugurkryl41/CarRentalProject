using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{Id=0,BrandId=2,ColorId=33,ModelYear=2014,DailyPrice=56929,Description="Info." },
                new Car{Id=1,BrandId=2,ColorId=15,ModelYear=2020,DailyPrice=96723,Description="Info." },
                new Car{Id=2,BrandId=2,ColorId=78,ModelYear=1994,DailyPrice=26173,Description="Info." },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedToCar = null;

            deletedToCar = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(deletedToCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();            
        }

        public Car Get(int id)
        {
            return _cars.SingleOrDefault(p => p.Id == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars.ToList();
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
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
            updatedToCar.Description = car.Description;
        }
    }
}
