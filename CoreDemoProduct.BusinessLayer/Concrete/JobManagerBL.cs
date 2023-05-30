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
    public class JobManagerBL : IGenericServiceBL<Job>
    {
        IJobDAL _jobDal;

        public JobManagerBL(IJobDAL jobDal)
        {
            _jobDal = jobDal;
        }

        public void TDelete(Job t)
        {
            _jobDal.Delete(t);
        }

        public Job TGetByID(int id)
        {
           return _jobDal.GetByID(id);
        }

        public List<Job> TGetList()
        {
            return _jobDal.GetList();
        }

        public void TInsert(Job t)
        {
            _jobDal.Insert(t);
        }

        public void TUpdate(Job t)
        {
            _jobDal.Update(t);
        }
    }
}
