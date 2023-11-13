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
    internal class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void AddColor(Color color)
        {
            _colorDal.Add(color);
        }

        public Color GetColor(int colorId)
        {
            return _colorDal.Get(c => c.ColorId == colorId);
        }

        public void DeleteColor(Color color)
        {
            _colorDal.Delete(color);
        }

        public void UpdateColor(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
