using System;
using OneNet.Core.Domain;

namespace OneNet.Customer.Domain
{
    public class Customer : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}