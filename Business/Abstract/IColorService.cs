using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    internal interface IColorService
    {
        void AddColor(Color color);
        void DeleteColor(Color color);
        void UpdateColor(Color color);
        Color GetColor(int colorId);
    }
}
