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
       
    }

    public class PaymentTypeDao : BaseDao<PaymentType>, IPaymentTypeDao
    {
        public PaymentTypeDao() : base()
        {
        }
    }
}
