using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Model.Order
{
    public class Order
    {
        public int Id { get; set; }

        public string TradeNo { get; set; }

        public int TotalFee { get; set; }
    }
}
