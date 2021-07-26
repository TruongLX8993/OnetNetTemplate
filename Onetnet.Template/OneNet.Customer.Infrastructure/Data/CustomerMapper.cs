using FluentNHibernate.Mapping;

namespace OneNet.Customer.Infrastructure.Data
{
    public class CustomerMapper : ClassMap<Domain.Customer>
    {
        public CustomerMapper()
        {

            Id(item => item.Id);
            Map(item => item.Name);
            Map(item => item.Phone);
            Map(item => item.Address);
            Table("Customer");
        }
    }
}