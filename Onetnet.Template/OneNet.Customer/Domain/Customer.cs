using System;
using OneNet.Base.Domain;

namespace OneNet.Customer.Domain
{
    public class Customer : BaseEntity<int>
    {
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
    }
}