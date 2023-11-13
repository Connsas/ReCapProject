using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car { CarName = "Deneme1", DailyPrice = 200, Description = "Açıklama1", ModelYear = 2001,};
            ICarService carService = new CarManager(new EfCarDal());
            //carService.AddCar(car);
            foreach (var item in carService.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarName);
            }
        }
    }
}