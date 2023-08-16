using IMS.BusinessModel.Dto.Customer;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Entity;
using NHibernate;
using System.Collections.Generic;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.Services.SecondaryServices
{
    public interface ICustomerService
    {
        void Create(CustomerFormDto customerFormDto, long userId, ISession session);
        void Delete(long entityId, ISession sess);
        List<CustomerDto> GetAll(ISession session, DataRequest dataRequest);
        int GetTotalCount(ISession session);
        CustomerDto MapToDto(Customer entity, CustomerDto dto);
        void Update(CustomerDto customerDto, long modifiedById, ISession sess);
        void UpdateRank(ChangeRankDto changeRankDto, ISession sess);
    }
}