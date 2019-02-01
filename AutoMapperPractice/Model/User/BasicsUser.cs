using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapperPractice.Model.Basics;

namespace AutoMapperPractice.Model.User
{
    public class BasicsUser:Base
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
