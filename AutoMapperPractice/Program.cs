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
            //BaseMap();
            NullMap();
        }

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
            Mapper.Initialize(cfg=>cfg.CreateMap<User,UserDto>());
            var userDto = Mapper.Map<User, UserDto>(user);
            Console.ReadKey();
        }
    }
}
