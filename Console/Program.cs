using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new ICarManager(new InMemoryCarDal());

            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Id);
            }
        }
    }
}