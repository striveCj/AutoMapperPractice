using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapperPractice.Attributes
{
    public class AutoMapperModule
    {
        private readonly ITypeFinder _typeFinder;

        public AutoMapperModule(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        public void Initialize()
        {
            CreateMappings();
        }

        public void CreateMappings()
        {    
            Mapper.Initialize(FindAndAutoMapTypes);
        }

        private void FindAndAutoMapTypes(IMapperConfigurationExpression configuration)
        {
            var types = _typeFinder.Find(type => type.IsDefined(typeof(AutoMapAttribute)));

            foreach (var type in types)
            {
                foreach (var autoMapAttribute in type.GetCustomAttributes<AutoMapAttributeBase>())
                {
                    autoMapAttribute.CreateMap(configuration, type);
                }
            }
        }
    }
}
