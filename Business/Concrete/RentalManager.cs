using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        //[SecuredOperation("rental.add", Priority = 1)]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(
                CheckIfCar(rental)
                );

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRental);
        }

        public IResult DateCheck(Rental rental)
        {
            var result = _rentalDal.GetAll().Where(p => p.CarId == rental.CarId && p.ReturnDate > rental.ReturnDate).ToList();
            if( result.Count != 0)
            {
                return new ErrorResult();
            }

          return new SuccessResult();
        }

        [SecuredOperation("rental.delete", Priority = 1)]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails()
                .Where(p=>p.CarId == carId).ToList());
        }

        [SecuredOperation("rental.update", Priority = 1)]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckIfCar(Rental rental)
        {
            var result = _rentalDal.GetAll(p => p.CarId == rental.CarId).Where(t => rental.RentDate > t.RentDate && rental.RentDate < t.ReturnDate).ToList();
            if (result.Count != 0)
            {
                return new ErrorResult("Araç Kullanımda");
            }

            return new SuccessResult();
        }
    }
}
