
//using IMS.Dao;
//using IMS.Dao.ConfigurationDaos;
//using NHibernate;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IMS.Services.ConfigurationServices
//{
//    public interface ICustomerTypeService
//    {
//        IEnumerable<CustomerTypeDto> GetAllCustomerTypes(ISession session);
//        void CreateCustomerType(CustomerTypeFormData CustomerTypeFormData, ISession session);
//        void UpdateCustomerType(CustomerTypeFormData CustomerTypeFormData, ISession session);
//        void DeleteCustomerType(long CustomerTypeId, ISession session);
//    }



//    public class CustomerTypeService : ICustomerTypeService
//    {
//        private ICustomerTypeDao _CustomerTypeDao;
//        public CustomerTypeService()
//        {

//        }
//        public CustomerTypeService(ICustomerTypeDao CustomerTypeDao)
//        {
//            _CustomerTypeDao = CustomerTypeDao;
//        }

//        public IEnumerable<CustomerTypeDto> GetAllCustomerTypes(ISession session)
//        {
//            // Assuming the Dao returns the entities, you need to map them to DTOs
//            _CustomerTypeDao = new CustomerTypeDao();
//            var CustomerTypes = _CustomerTypeDao.GetAll(session);
//            return CustomerTypes.Select(MapToDto);
//        }

//        public void CreateCustomerType(CustomerTypeFormData CustomerTypeFormData, ISession session)
//        {
//            using (var transaction = session.BeginTransaction())
//            {
//                try
//                {
//                    // Map the DTO to the entity
//                    var CustomerTypeEntity = MapToEntity(CustomerTypeFormData);
//                    _CustomerTypeDao = new CustomerTypeDao();

//                    // Call the DAO to save the new CustomerType entity to the database
//                    _CustomerTypeDao.Create(CustomerTypeEntity, session);
//                    transaction.Commit();
//                }
//                catch (Exception ex)
//                {
//                    transaction.Rollback();
//                    throw ex;
//                }
//            }
//        }

//        public void UpdateCustomerType(CustomerTypeFormData CustomerTypeFormData, ISession session)
//        {
//            using (var transaction = session.BeginTransaction())
//            {
//                try
//                {
//                    // Map the DTO to the entity
//                    var CustomerTypeEntity = MapToEntity(CustomerTypeFormData);
//                    _CustomerTypeDao = new CustomerTypeDao();

//                    // Call the DAO to save the new CustomerType entity to the database
//                    _CustomerTypeDao.Update(CustomerTypeEntity, session);
//                    transaction.Commit();
//                }
//                catch (Exception ex)
//                {
//                    transaction.Rollback();
//                    throw ex;
//                }
//            }
//        }

//        public void DeleteCustomerType(long CustomerTypeId, ISession session)
//        {
//            using (var transaction = session.BeginTransaction())
//            {
//                try
//                {
//                    _CustomerTypeDao = new CustomerTypeDao();
//                    var CustomerTypeEntity = _CustomerTypeDao.GetById(CustomerTypeId, session);
//                    if (CustomerTypeEntity != null)
//                    {
//                        _CustomerTypeDao.Delete(CustomerTypeEntity, session);
//                    }
//                    transaction.Commit();
//                }
//                catch (Exception ex)
//                {
//                    transaction.Rollback();
//                    throw ex;
//                }
//            }
//        }
//    }
//}
