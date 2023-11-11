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
    public class ICarManager : ICarService
    {
        ICarDal carDal;

        public ICarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        public void Add(Car car)
        {
            carDal.Add(car);
        }

        public void Delete(Car car)
        {
            carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return carDal.GetAll();
        }

        public List<Car> GetById(int id)
        {
            return carDal.GetById(id);
        }

        public void Update(Car car)
        {
            carDal.Update(car);
        }
    }
}
