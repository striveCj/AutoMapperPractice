using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice.Model.Book
{
    public class Book
    {
        public string Title { get; set; }

        public Author Author { get; set; }
    }
}
