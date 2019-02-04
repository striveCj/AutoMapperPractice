using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPractice.Model.Customer;

namespace AutoMapperPractice.Resolver
{
    public class VIPResolver:IValueResolver<CustomerVip,CustomerVipDTO,string>
    {
        public string Resolve(CustomerVip source,CustomerVipDTO destination,string destMember,ResolutionContext context)
        {
            return source.VIP ? "Y" : "N";
        }
    }
}
