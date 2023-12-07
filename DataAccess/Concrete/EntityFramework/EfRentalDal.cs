using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfRepositoryBaseDal<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<CarRentalDto> GetCarRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join u in context.Customers on r.CustomerId equals u.CustomerId
                             select new CarRentalDto()
                             {
                                 CarName = c.CarName,
                                 CustomerName = u.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            };
        }
    }
}
