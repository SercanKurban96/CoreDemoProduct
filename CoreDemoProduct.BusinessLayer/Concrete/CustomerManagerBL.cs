using CoreDemoProduct.BusinessLayer.Abstract;
using CoreDemoProduct.DataAccessLayer.Abstract;
using CoreDemoProduct.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoProduct.BusinessLayer.Concrete
{
    public class CustomerManagerBL : IGenericServiceBL<Customer>
    {
        ICustomerDAL _customerDal;
        public CustomerManagerBL(ICustomerDAL customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetCustomersListWithJob()
        {
            return _customerDal.GetCustomerListWithJob();
        }

        public void TDelete(Customer t)
        {
            _customerDal.Delete(t);
        }

        public Customer TGetByID(int id)
        {
            return _customerDal.GetByID(id);
        }

        public List<Customer> TGetList()
        {
            return _customerDal.GetList();
        }

        public void TInsert(Customer t)
        {
            _customerDal.Insert(t);
        }

        public void TUpdate(Customer t)
        {
            _customerDal.Update(t);
        }
    }
}
