using IMS.BusinessModel.Entity.Configuration;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Dao
{
    public interface IPaymentTypeDao : IBaseDao<PaymentType>
    {
        // Add specific query methods for the PaymentType entity if needed
        // For example, you can add methods to retrieve PaymentTypes by name, status, etc.
    }

    public class PaymentTypeDao : BaseDao<PaymentType>, IPaymentTypeDao
    {
        public PaymentTypeDao() : base()
        {
        }

        // Implement additional methods specific to the PaymentType entity if needed
        // For example, you can add methods to retrieve PaymentTypes by name, status, etc.
    }


}
