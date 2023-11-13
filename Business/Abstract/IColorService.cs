using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    internal interface IColorService
    {
        IResult AddColor(Color color);
        IResult DeleteColor(Color color);
        IResult UpdateColor(Color color);
        IDataResult<Color> GetColor(int colorId);
    }
}
