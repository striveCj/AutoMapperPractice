using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPractice.Model.Customer;

namespace AutoMapperPractice.Converter
{
    public class CustomTypeConverter:ITypeConverter<CustomerVip,CustomerVipDTO>
    {
        public CustomerVipDTO Convert(CustomerVip source, CustomerVipDTO destination, ResolutionContext context)
        {
           return new CustomerVipDTO
           {
               VIP = source.VIP?"Y":"N"
           };
        }
    }
}
