using DrakeShop.Cargo.DataAccessLayer.Abstract;
using DrakeShop.Cargo.DataAccessLayer.Concrete;
using DrakeShop.Cargo.DataAccessLayer.Repositories;
using DrakeShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {

        }
    }
}
