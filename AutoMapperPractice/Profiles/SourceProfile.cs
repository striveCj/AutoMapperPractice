using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPractice.Model.Demo;

namespace AutoMapperPractice.Profiles
{
    public class SourceProfile:Profile
    {
        protected  void Configure()
        {
            CreateMap<Source, Destination>();
            //CreateMap<Source, Destination>()
            //    .ForMember(d => d.AnotherValue2, opt => opt.MapFrom(s => s.AnotherValue));
        }

    }
}
