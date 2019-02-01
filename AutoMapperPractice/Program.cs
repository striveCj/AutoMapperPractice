using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPractice.Model.User;

namespace AutoMapperPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 初级使用方法调用
            //基础映射
            //BaseMap();
            //当映射源为null时
            //NullMap();
            //当映射源大小写有差异时
            //LowercaseMap();
            #endregion

            #region 中级方法调用
            //继承映射
            InheritanceMap();


            #endregion

        }

        #region 初级使用方法

        public static void BaseMap()
        {
            var user = new User
            {
                Id = 1,
                Age = 10,
                Name = "chenjie"
            };
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
            var mapper = config.CreateMapper();
            var userDto = mapper.Map<User, UserDto>(user);
            Console.WriteLine($"姓名{userDto.Name}年龄{userDto.Age}编号{userDto.Id}");
            Console.ReadKey();
        }
        //AutoMapper将映射源映射到目标时，AutoMapper将忽略空引用异常。 这是AutoMapper默认设计。
        public static void NullMap()
        {
            User user = null;
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            var userDto = Mapper.Map<User, UserDto>(user);
            Console.ReadKey();
        }
        //默认情况下AutoMapper从映射源到映射目标时不区分大小写。
        public static void LowercaseMap()
        {
            var userLowercase = new UserLowercase
            {
                id = 1,
                age = 10,
                name = "chenjie"
            };
            Mapper.Initialize(cfg => cfg.CreateMap<UserLowercase, UserDto>());

            var userDto = Mapper.Map<UserLowercase, UserDto>(userLowercase);
            Console.WriteLine($"姓名{userDto.Name}年龄{userDto.Age}编号{userDto.Id}");
            Console.ReadKey();

        }

        #endregion

        #region 中级使用方法
        //AutoMapper从映射源到映射目标支持继承
        public static void InheritanceMap()
        {
            var user=new BasicsUser
            {
                Id=1,
                Age=10,
                Name="Jeffcky",
                CreatedTime=DateTime.Now,
                ModifiedTime = DateTime.Now
            };
            Mapper.Initialize(cfg=>cfg.CreateMap<BasicsUser,BasicsUserDto>());
            var userDto = Mapper.Map<BasicsUser, BasicsUserDto>(user);
            Console.WriteLine($"姓名{userDto.Name}年龄{userDto.Age}编号{userDto.Id}创建时间{userDto.CreatedTime}修改时间{userDto.ModifiedTime}");
            Console.ReadKey();
        }


        #endregion


    }
}
