using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            _carDal.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);
        }

        public Car GetCar(int carId)
        {
            return _carDal.Get(p=> p.CarId == carId);
        }

        public void UpdateCar(Car car)
        {
            _carDal.Update(car);
        }
    }
}
