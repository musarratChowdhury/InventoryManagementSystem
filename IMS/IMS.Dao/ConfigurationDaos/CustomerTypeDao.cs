using IMS.BusinessModel.Entity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Dao.ConfigurationDaos
{
    public interface ICustomerTypeDao : IBaseDao<CustomerType>
    {

    }

    public class CustomerTypeDao : BaseDao<CustomerType>, ICustomerTypeDao
    {
        public CustomerTypeDao() : base()
        {
        }
    }
}
