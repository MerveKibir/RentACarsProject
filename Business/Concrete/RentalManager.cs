using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarService _carService;
        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        public IResult Add(Rental rental)
        {
            return this.Add2(rental);
        }

        public IResult Rentalable(Rental rental)
        {
            return new SuccessResult();
        }

        public IResult CheckRentCar(int carId)
        {
            Rental isCarRented = this.GetByCarId(carId).Data;
            if (isCarRented != null && isCarRented.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarRented);
            }
            return new SuccessResult();
        }


        public IResult Delete(Rental rental)
        {

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId), Messages.RentalGetCarId);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.RentalGot);
        }

        public IDataResult<List<RentalDetailDto>> getRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.rentalDetails(), "Araba kiraları listelendi");
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<Rental> Add2(Rental rental)
        {
            IResult result = BusinessRules.Run(this.Rentalable(rental));
            if (result != null)
            {
                return new ErrorDataResult<Rental>(null, result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(rental, Messages.RentalAdded);
        }

        public IDataResult<int> GetTotalRentalCount()
        {
            return new SuccessDataResult<int>(_rentalDal.GetTotalRentalCount());
        }
    }
}