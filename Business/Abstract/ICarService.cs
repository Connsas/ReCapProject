using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult AddCar(Car car);
        IResult DeleteCar(Car car);
        IResult UpdateCar(Car car);
        IDataResult<Car> GetCar(int carId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
    }
}
