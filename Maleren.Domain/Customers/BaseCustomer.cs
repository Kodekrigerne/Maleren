using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maleren.Domain.Orders;

namespace Maleren.Domain.Customers
{
    public abstract class BaseCustomer : BaseEntity
    {
        public List<Order> Orders { get; protected set; }
        //TODO: Extra attributes like address, etc 
    }
}
