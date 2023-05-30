using CoreDemoProduct.DataAccessLayer.Abstract;
using CoreDemoProduct.DataAccessLayer.Concrete;
using CoreDemoProduct.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemoProduct.DataAccessLayer.EntityFramework
{
    public class EfJobDAL : RepositoryDAL<Job>, IJobDAL
    {
    }
}
