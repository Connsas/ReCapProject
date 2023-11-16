using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImages carImages);
        IResult Delete(CarImages carImages);
        IResult Update(IFormFile file, CarImages carImages);
        IDataResult<CarImages> Get(int carImagesId);
        IDataResult<List<CarImages>> GetCarImages(int id);
    }
}
