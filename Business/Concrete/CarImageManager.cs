using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class CarImageManager : ICarImageService
    {
        ICarImagesDal _carImageDal;
        FileHelper _fileHelper;

        public CarImageManager(ICarImagesDal carImageDal, FileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckCarImagesAmount(carImages.CarId));
            if (!result.Success)
            {
                return new ErrorResult();
            }
            string filePath;
            filePath = _fileHelper.CreateFile(file, FolderPaths.ResourcesPath).Data;
            carImages.ImagePath = filePath;
            carImages.Date = DateTime.Now;
            _carImageDal.Add(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetCarImages(int id)
        {
            var result = BusinessRules.Run(CheckAnyCarImages(id));
            if (!result.Success)
            {
                List<CarImages> defaultImage = new List<CarImages>();
                defaultImage.Add(new CarImages { CarId = id, Date = DateTime.Now, ImagePath = FolderPaths.DefaultImagePath });
                return new SuccessDataResult<List<CarImages>>(defaultImage) ;
            }
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IResult Delete(CarImages carImages)
        {
            var result = Get(carImages.ImageId);
            _fileHelper.DeleteFile(FolderPaths.ResourcesPath + result.Data.ImagePath);
            _carImageDal.Delete(carImages);
            return new SuccessResult();
        }

        public IDataResult<CarImages> Get(int carImagesId)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.ImageId == carImagesId));
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            throw new NotImplementedException();
        }
        private IResult CheckCarImagesAmount(int id)
        {
            if (_carImageDal.GetAll(c => c.CarId == id).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageAmountExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckAnyCarImages(int id)
        {
            if (!_carImageDal.GetAll(c => c.CarId == id).Any())
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
