using CoreDemoProduct.DataAccessLayer.Abstract;
using CoreDemoProduct.DataAccessLayer.Concrete;
using CoreDemoProduct.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoProduct.DataAccessLayer.EntityFramework
{
    public class EfCustomerDAL : RepositoryDAL<Customer>, ICustomerDAL
    {
        public List<Customer> GetCustomerListWithJob()
        {
            using (var c = new Context())
            {
                return c.Customers.Include(x => x.Job).ToList();
            }
        }
    }
}
