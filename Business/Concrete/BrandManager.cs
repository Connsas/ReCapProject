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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public Brand GetBrand(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
        }

        public void UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
