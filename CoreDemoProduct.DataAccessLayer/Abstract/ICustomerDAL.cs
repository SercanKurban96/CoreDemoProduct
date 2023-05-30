using CoreDemoProduct.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoProduct.DataAccessLayer.Abstract
{
    public interface ICustomerDAL : IRepositoryDAL<Customer>
    {
        List<Customer> GetCustomerListWithJob();
    }
}
