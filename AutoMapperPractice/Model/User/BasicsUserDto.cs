using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Model.User
{
    public class BasicsUserDto
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }

        public DateTime ModifiedTime { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }
    }
}
