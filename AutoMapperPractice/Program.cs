using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperPractice.Converter;
using AutoMapperPractice.Model.User;
using AutoMapperPractice.Model.Address;
using AutoMapperPractice.Model.Book;
using AutoMapperPractice.Model.Customer;
using AutoMapperPractice.Model.Demo;
using AutoMapperPractice.Model.Order;
using AutoMapperPractice.Profiless;
using AutoMapperPractice.Resolver;
using CustomerDTO = AutoMapperPractice.Model.Customer.CustomerDTO;

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
            //复杂映射
            OptionMap();

            #endregion

            #region 中级方法调用

            //继承映射
            //InheritanceMap();
            //扁平映射
            //MuiMap();
            //映射规则
            //BpMap();
            //集合映射
            //ListMap();

            #endregion

            #region 高级方法调用

            //自定义配置
            //ConfigMap();
            //动态配置
            //DynamicMap();
            //类型转换
            //TypeMap();

            #endregion

            #region Profile用法

            //ProfileMap();

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

        /// <summary>
        /// 复杂自定义配置
        /// </summary>
        public static void OptionMap()
        {
            var books = new Book
            {
                Author = new Author
                {
                    FirstName = "陈",
                    LastName = "杰"
                },
                Title = "你的名字"
            };

            AutoMapper.Mapper.Initialize(cfg=>cfg.CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Author,opts=>opts.MapFrom(src=>string.Format($"{src.Author.FirstName}{src.Author.LastName}"))));

            var bookDto = Mapper.Map<BookViewModel>(books);
            Console.WriteLine(bookDto.Title+bookDto.Author);
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
        //AutoMapper支持从映射源到映射目标的扁平化。
        public static void MuiMap()
        {
            var author = new AuthorModel
            {
                Id=1,
                FirstName="chen",
                LastName="jie",
                Address=new Address()
                {
                    City="深圳",
                    State="1",
                    Country="中国"
                }
            };
            Mapper.Initialize(cfg=>cfg.CreateMap<AuthorModel,AuthorDTO>()
                .ForMember(d=>d.City,o=>o.MapFrom(s=>s.Address.City))
                .ForMember(d=>d.State,o=>o.MapFrom(s=>s.Address.State))
                .ForMember(d=>d.Country,o=>o.MapFrom(s=>s.Address.Country))
            .ForMember(d=>d.Id,o=>o.Ignore()));//AutoMapper中有Ignore方法来忽略映射，如下代码片段将忽略对属性Id的映射

            var authorDTO = Mapper.Map<AuthorModel, AuthorDTO>(author);

            Console.ReadKey();
        }
        //AutoMapper映射规则
        //如果扁平化映射源类，若想AutoMapper依然能够自动映射，那么映射目标类中的属性必须是映射源中复杂属性名称加上复杂属性中的属性名称才行，因为AutoMapper会深度搜索目标类，直到找到匹配的属性为止。
        public static void BpMap()
        {
            var customer = new Customer
            {
                Company = new Company
                {
                    Name = "腾讯"
                }
            };
            Mapper.Initialize(cfg=>cfg.CreateMap<Customer,CustomerDTO>());
            var customerDTO = Mapper.Map<Customer, CustomerDTO>(customer);
            Console.WriteLine(customerDTO.CompanyName);
            Console.ReadKey();
        }
        //集合映射
        public static void ListMap()
        {
            var customer = new CustomerOrder
            {
                Id = 1,
                Name = "chenjie",
                Orders = new List<Order>
                {
                    new Order
                    {
                        Id=1,
                        TotalFee = 10,
                        TradeNo = "20172021690326"
                    }
                }
            };

            Mapper.Initialize(cfg=>cfg.CreateMap<CustomerOrder,CustomerOrderDTO>()
            .ForMember(d=>d.OrderDtos,o=>o.MapFrom(s=>s.Orders)));

            var customerDTO = Mapper.Map<CustomerOrder, CustomerOrderDTO>(customer);

            Console.ReadKey();
        }
        #endregion

        #region 高级使用方法
        /// <summary>
        /// 自定义配置
        /// </summary>
        public static void ConfigMap()
        {
            var customer = new CustomerVip
            {
                VIP = true
            };
            Mapper.Initialize(cfg=>cfg.CreateMap<CustomerVip,CustomerVipDTO>()
            .ForMember(cv=>cv.VIP,m=>m.MapFrom<VIPResolver>()));
            var customerDto = Mapper.Map<CustomerVip, CustomerVipDTO>(customer);

        }
        /// <summary>
        /// 动态映射
        /// </summary>
        public static void DynamicMap()
        {
            dynamic customer=new ExpandoObject();
            customer.Id = 5;
            customer.Name = "Chenjie";
            Mapper.Initialize(cfg=> {});
            var result = Mapper.Map<CustomerDynamic>(customer);
            dynamic foo2 = Mapper.Map<ExpandoObject>(result);
        }
        /// <summary>
        /// 类型转换
        /// </summary>
        public static void TypeMap()
        {
            var customer = new CustomerVip
            {
                VIP = true
            };
            //Mapper.Initialize(cfg => cfg.CreateMap<CustomerVip, CustomerVipDTO>()
            //    .ConvertUsing(s=>new CustomerVipDTO
            //    {
            //        VIP = s.VIP?"y":"n"
            //    }));
            //var customerDto = Mapper.Map<CustomerVip, CustomerVipDTO>(customer);
            Mapper.Initialize(cfg => cfg.CreateMap<CustomerVip, CustomerVipDTO>()
                .ConvertUsing(new CustomTypeConverter()));
            var customerDtp2= Mapper.Map<CustomerVip, CustomerVipDTO>(customer);
        }

        #endregion

        #region Profile用法

        public static void ProfileMap()
        {
            Mapper.Initialize(x => x.AddProfile<SourceProfile>());
            var sou = new Source
            {
                Id = 1,
                Name ="ChenJie",
                Age = 20

            };
            
            var des = Mapper.Map<Destination>(sou);
        }
        

        #endregion
    }
}
