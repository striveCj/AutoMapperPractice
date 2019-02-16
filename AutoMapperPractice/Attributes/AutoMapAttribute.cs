using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPractice.Extensions;

namespace AutoMapperPractice.Attributes
{
    public class AutoMapAttribute:AutoMapAttributeBase
    {
        public AutoMapAttribute(params Type[] targetTypes):base(targetTypes)
        {
            
        }

        public override void CreateMap(IMapperConfigurationExpression configuration, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                
            }
        }

    }

}
