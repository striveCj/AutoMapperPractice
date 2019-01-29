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
            BaseMap();
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
    }
}
