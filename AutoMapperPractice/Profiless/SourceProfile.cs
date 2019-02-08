using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPractice.Model.Demo;

namespace AutoMapperPractice.Profiless
{
    public class SourceProfile: Profile
    {
        public SourceProfile()
        {
            //CreateMap<Source, Destination>();
            base.CreateMap<Source, Destination>()
                .ForMember(d => d.Name2, opt => opt.MapFrom(s => s.Name));
        }
        //AutoMapper在6.0版本时移除了Profile中的Configure，所以与6.0版本以下写法有点不同，6.0以下版本写法为：
        //protected override void Configure()
        //             {
        //                CreateMap<Source, DTOSource>().ForMember(c => c.Desc, q => {
        //                        q.MapFrom(z => z.Content);
        //                    });
        //            }

}
}
