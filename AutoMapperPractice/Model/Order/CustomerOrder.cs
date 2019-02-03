using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Model.Order
{
    public class CustomerOrder
    {

        public int Id { get; set; }

        public string Name { get; set; }

         public IEnumerable<Order> Orders { get; set; }
    }
}
