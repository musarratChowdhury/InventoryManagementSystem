using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity;

namespace IMS.Dao.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer"); // Specify the table name if different

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Address);
            Map(x => x.Email);
            Map(x => x.Phone);
            Map(x => x.Status);
            Map(x => x.CreatedBy);
            Map(x => x.CreationDate);
            Map(x => x.ModifiedBy);
            Map(x => x.ModificationDate);
            Map(x => x.Rank);
            Map(x => x.BusinessId);
            Map(x => x.Version);

            References(x => x.CustomerType, "Id"); // Navigation property mapping
        }
    }
}
