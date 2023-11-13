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
            _cars = new List<Car> { 
                new Car {CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 200, Description = "Mavi Dacia", ModelYear = 2010 },
                new Car {CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 200, Description = "Sarı Dacia", ModelYear = 2008 },
                new Car {CarId = 3, BrandId = 1, ColorId = 3, DailyPrice = 200, Description = "Kırmızı Dacia", ModelYear = 2014 },
                new Car {CarId = 4, BrandId = 1, ColorId = 4, DailyPrice = 200, Description = "Turuncu Dacia", ModelYear = 2012 }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deleteCar = _cars.SingleOrDefault(p=> p.CarId == car.CarId);
            _cars.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p=> p.CarId == id).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var deleteCar = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(deleteCar);
            _cars.Add(car);
        }
    }
}
